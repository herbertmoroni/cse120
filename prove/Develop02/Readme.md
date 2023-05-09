## W03 Team Activity: Designer

The console app is made up of four classes: `Program`, `Journal`, `Entry` and `PromptHandler`.

The `Program` class has the main method that creates an instance of the `Journal` class and manages user input by showing a menu and calling the right methods on the `Journal` object based on the user's selection.

The `Journal` class represents the journal itself and has a list of `Entry` objects. The class has methods for adding a new entry, displaying all entries, saving the journal to a file, and loading the journal from a file. This class also uses `PromptHandler` that stores a list of prompts and return one ramdom using method `GetRamdomPrompt`

The `Entry `class represents an individual entry in the journal and has information like the user's response, the prompt that was used, and the date the entry was made. The `DisplayEntry` display a string representation of the `Entry` object in the format of "date,prompt,response".



