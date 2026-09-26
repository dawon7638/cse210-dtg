using System;
using System.Collections.Generic;

class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();

        Reference reference1 = new Reference("John", 3, 16);

        Scripture scripture1 = new Scripture(
            reference1,
            "For God so loved the world that he gave his only begotten Son " +
            "that whosoever believeth in him should not perish but have everlasting life."
        );

        _scriptures.Add(scripture1);


        Reference reference2 = new Reference("Proverbs", 3, 5, 6);

        Scripture scripture2 = new Scripture(
            reference2,
            "Trust in the Lord with all thine heart and lean not unto thine own understanding " +
            "In all thy ways acknowledge him and he shall direct thy paths."
        );

        _scriptures.Add(scripture2);


        Reference reference3 = new Reference("Philippians", 4, 13);

        Scripture scripture3 = new Scripture(
            reference3,
            "I can do all things through Christ which strengtheneth me."
        );

        _scriptures.Add(scripture3);
    }

    public Scripture GetRandomScripture()
    {
        int randomIndex = _random.Next(_scriptures.Count);

        return _scriptures[randomIndex];
    }
}