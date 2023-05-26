// This class wll store the refrence string
// and the text string while keeping it private
using System;

namespace Develop03
{
class Scripture
{
    private string _refrence = "John 3:16";
    private string _sacredText  = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him \nshould not perish, but have everlasting life.";

    public string GetScripture()
    {
       string refrence = _refrence;
       string sacredText = _sacredText;
       return $"{refrence} {sacredText}";
    }
    public string GetScriptText()
    {
       string sacredText = _sacredText;
       return $"{sacredText}";
    }
    public string GetVerseHeader()
    {
        string VerseReference = _refrence;
        return $"{VerseReference}";
    }
    
}
}