using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Cinemachine;
using System;


public class DialogueManager : MonoBehaviour
{



    public static event Action OnEnterDialogueMode;



    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator potraitAnimator;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;



    private const string SpeakerTag = "speaker";
    private const string PotraitTag = "potrait";





    public Animator dialoganimator;


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; } //use to freeze player when dialogue is playing

    public static DialogueManager instance;


    public GameObject Player;
    bool isChoosing=false;

    CinemachineVirtualCamera dialogueCineMachineCamera;
    QuestGiver currentQuest;
    NPC_Class currentNpc;
    Animator currentNPCAnimator;
    QuestGiver currentOnGoingQuest;
    bool currentNonQuestNPC;


    public bool InDialogue;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        


    }


    private void Start()
    {
        dialogueIsPlaying = false;
        //dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    private void Update()
    {
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0) && !isChoosing)
        {

            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, CinemachineVirtualCamera cineMachineCamera,QuestGiver questGiver, NPC_Class npc_Class,Animator npc_animator,bool isNonQuestNPC)
    {

       

        SetQuestProperty(cineMachineCamera,questGiver,npc_Class,npc_animator,isNonQuestNPC);
        AnimationController.instance.PlayAnimation(currentNPCAnimator,"Blend",1);
        InDialogue = true;

        Player.GetComponent<PlayerInputSystem>().enabled = false;
        Debug.Log("yes");

        dialoganimator.SetBool("isOpen", true);

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        // dialoguePanel.SetActive(true);

       // displayNameText.text = "Name";
       // potraitAnimator.Play("PotraitDefaultAnimation");


        ContinueStory();
       

    }


    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0);

        dialogueIsPlaying = false;
        // dialoguePanel.SetActive(false);
        dialogueText.text = "";

        dialoganimator.SetBool("isOpen", false);

        Player.GetComponent<PlayerInputSystem>().enabled = true;




        if (currentNonQuestNPC)
        {
            currentNpc.CurrentNpcState = NPC_Class.NpcState.NpcCompleteQuest;
            Quest_Class.instance.CurrentState = Quest_Class.QuestState.QuestFetched;
            StartQuestProperty();
        }

        else {


            if (!Quest_Class.instance.isQuestActive && !currentNpc.isQuestDone)
            {
                StartQuestProperty();
                Quest_Class.instance.CurrentState = Quest_Class.QuestState.AmidQuest;
                Quest_Class.instance.isQuestActive = true;
                currentNpc.CurrentNpcState = NPC_Class.NpcState.NpcAmidQuest;
            }
            else if (Quest_Class.instance.CurrentState == Quest_Class.QuestState.AmidQuest && currentNpc.CurrentNpcState == NPC_Class.NpcState.NpcAmidQuest)
            {

                StartQuestProperty();

            }
            else if (Quest_Class.instance.isQuestActive && !currentNpc.isQuestDone && currentNpc.CurrentNpcState == NPC_Class.NpcState.NpcCompleteQuest)
            {

                currentNpc.isQuestDone = true;
                Quest_Class.instance.isQuestActive = false;
                currentNpc.CurrentNpcState = NPC_Class.NpcState.NpcAfterQuest;
                Quest_Class.instance.CurrentState = Quest_Class.QuestState.BeforeQuest;
                StartQuestProperty();

                Debug.Log("Kaj  sesh");


            }
            else
            {
                StartQuestProperty();
            }
        }
        AnimationController.instance.PlayAnimation(currentNPCAnimator, "Blend", 0);
        InDialogue = false;
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            DisplayChoices();

            HandleTags(currentStory.currentTags);    

        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag couldn't be parsed appropriately" + tag);

            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch(tagKey)
            {
                case SpeakerTag:

                    displayNameText.text = tagValue;
                    //Debug.Log("Speaker:" + tagValue);
                    break;
                case PotraitTag:
                    potraitAnimator.Play(tagValue);
                    //Debug.Log("potrait:" + tagValue);
                    break;
            }
        }
    }



    private void DisplayChoices()
    {

       
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        if (currentChoices.Count>0)
        {
            isChoosing = true;

        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

       // StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();


        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        isChoosing = false;
       
        ContinueStory();
    }
     public void SetQuestProperty(CinemachineVirtualCamera cineMachineCamera, QuestGiver questGiver,NPC_Class npc_Class,Animator npc_animator,bool isNonQuestNpc)
    {
        dialogueCineMachineCamera = cineMachineCamera;

       

        currentQuest = questGiver;
        currentNpc = npc_Class;
        currentNPCAnimator = npc_animator;
        currentNonQuestNPC= isNonQuestNpc;
    }

    public void StartQuestProperty()
    {


          dialogueCineMachineCamera.Priority = 8;


        if (!Quest_Class.instance.isQuestActive && !currentNpc.isQuestDone)
        {
            // currentQuest.GiveQuest();
            currentOnGoingQuest = currentQuest;
        }

        else if(!Quest_Class.instance.isQuestActive && currentNpc.isQuestDone)
        {
            currentOnGoingQuest = null;
        }

        

           
        
       
    }



    public QuestGiver ShowCurrentQuest()
    {
        return currentOnGoingQuest;
    }
}
