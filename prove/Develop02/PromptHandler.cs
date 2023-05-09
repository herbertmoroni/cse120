public static class PromptHandler
{
    private static string _lastPrompt;

    private static List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public static string GetRandomPrompt()
    {
        string prompt;
        do
        {
            prompt = _prompts[new Random().Next(_prompts.Count)];
        } while (prompt == _lastPrompt); //to not send same question twice in sequence
        _lastPrompt = prompt; 
        return prompt;
    }
}