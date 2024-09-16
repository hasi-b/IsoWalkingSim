-> main

=== main ===
OLD LADY: hi how are u
PLAYER: Which direction will you go?
	+[North]
		->chosen("North")
	+[South]
		->chosen("South")	

		
=== chosen(direction)===
We are going {direction}!!!		

-> END