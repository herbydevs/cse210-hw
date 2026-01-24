using System;
using System.Collections.Generic; 

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the string text into an array of strings
        string[] splitText = text.Split(' ');

        // Loop through the strings and create Word objects
        foreach (string wordText in splitText)
        {
            Word newWord = new Word(wordText);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Stretch Challenge: Randomly select from only those words that are not already hidden.
        // Using a list of candidates is more efficient than guessing random indices.
        
        Random random = new Random();
        
        // 1. Get a list of words that are currently visible
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                visibleWords.Add(word);
            }
        }

        // 2. Determine how many we can actually hide
        // If the user asks to hide 3, but only 2 are left, we hide 2.
        int count = 0;
        while (count < numberToHide && visibleWords.Count > 0)
        {
            // Pick a random index from the *visibleWords* list
            int index = random.Next(visibleWords.Count);
            
            // Hide that word
            visibleWords[index].Hide();
            
            // Remove it from the temporary list so we don't pick it again this turn
            visibleWords.RemoveAt(index);
            
            count++;
        }
    }

    public string GetDisplayText()
    {
        // Start with the reference text
        string displayText = _reference.GetDisplayText() + " ";

        // Add each word to the string
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        // Loop through all words. If we find even one that is NOT hidden, return false.
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
        
        // If we finished the loop without returning false, it means all words are hidden.
        return true;
    }
}