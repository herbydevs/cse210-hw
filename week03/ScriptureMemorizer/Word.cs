using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false; // By default, the word is visible
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // If hidden, return underscores based on the length of the word
            return new string('_', _text.Length);
        }
        else
        {
            // If not hidden, just return the text
            return _text;
        }
    }
}