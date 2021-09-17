/*
 * Author: Abbey Singh
 * This holds a list of story/mappings pair (MapData objects)
 */

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stories
{
    public List<StoryData> StoriesList = new List<StoryData>();
    public List<string> MapNames = new List<string>();
    public List<Map> maps = new List<Map>() ;
    public List<AttributeSS> Attributes = new List<AttributeSS>(); 
    public StoryData CurrentStory;
    public List<Color> Colors = new List<Color>();

    //Singleton
    private static Stories _instance;
    public static Stories Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Stories();

                Stories.Instance.AddDefaultAttributes();
                Stories.Instance.AddDefaultMaps();
            }
            return _instance;
        }
    }

    public void AddNewAttribute(AttributeSS newAttribute)
    {
        Attributes.Add(newAttribute);
    }

    public List<AttributeSS> GetAttributes()
    {
        return Attributes;
    }

    public AttributeSS FindAttribute(string name)
    {
        foreach(var attribute in Attributes)
        {
            if(attribute.AttributeName == name)
            {
                return attribute;
            }
        }

        return null;
    }

    public void DeleteAttribute(string name)
    {
        for(int i = 0; i < Attributes.Count; i++)
        {
            if (Attributes[i].AttributeName == name)
            {
                Attributes.RemoveAt(i);
                return;
            }
        }
    }

    public bool IsUniqueAttributeName(string attributeName)
    {
        foreach (var attribute in Attributes)
        {
            if (attribute.AttributeName == attributeName)
            {
                return false;
            }
        }

        return true;
    }


    public void AddColor(Color color)
    {
        Colors.Add(color);
    }

    public void RemoveColor(Color color)
    {
        Colors.Remove(color);
    }

    public Color GenerateUniqueColor()
    {
        Color color = Color.white; //needs a default value
        bool colorIsUnique = false;

        while (!colorIsUnique)
        {
            color = new Color(UnityEngine.Random.Range(0F, 1F), UnityEngine.Random.Range(0, 1F), UnityEngine.Random.Range(0, 1F));

            bool tempCheck = false;
            foreach (var existingColor in Colors)
            {
                if(existingColor.Equals(color))
                {
                    tempCheck = true;
                    break;
                }
            }

            if (!tempCheck)
            {
                colorIsUnique = true;
            }
        }

        AddColor(color);
        return color;
    }

    // By default there are two maps: Goldberg and Mona Campbell building
    public void AddDefaultMaps()
    {
        Map map1 = new Map("Mona Campbell", 47, 28);
        Map map2 = new Map("Goldberg", 64, 24.5f);

        maps.Add(map1);
        maps.Add(map2);
    }

    public Map GetMap(string mapName)
    {
        foreach(var map in maps)
        {
            if(map.MapName == mapName)
            {
                return map;
            }
        }

        return null;
    }

    public void AddDefaultAttributes()
    {
        AttributeSS hidden = new AttributeSS("Hidden", new List<string> { "None", "Lowest", "Low" });
        Attributes.Add(hidden);

        AttributeSS easyToFind = new AttributeSS("Easy to Find", new List<string> { "None", "None", "Highest" });
        Attributes.Add(easyToFind);

        AttributeSS openArea = new AttributeSS("Open Area", new List<string> { "Highest", "None", "None" });
        Attributes.Add(openArea);

        AttributeSS closedArea = new AttributeSS("Closed Area", new List<string> { "Lowest", "None", "None" });
        Attributes.Add(closedArea);

        AttributeSS centralArea = new AttributeSS("Central Area", new List<string> { "None", "None", "Highest" });
        Attributes.Add(centralArea);

        AttributeSS uncentralArea = new AttributeSS("Uncentral Area", new List<string> { "None", "None", "Lowest" });
        Attributes.Add(uncentralArea);

        AttributeSS random = new AttributeSS("Random", new List<string> { "None", "None", "None" });
        Attributes.Add(random);
    }

    public void AddMap(string mapName)
    {
        MapNames.Add(mapName);
    }

    public List<String> GetMaps()
    {
        return MapNames;
    }

    public void RemoveMap(string mapName)
    {
        MapNames.Remove(mapName);
    }

    public bool IsUniqueMapName(string mapName)
    {
        foreach (var map in MapNames)
        {
            if (map == mapName)
            {
                return false;
            }
        }

        return true;
    }

    public void AddStory(StoryData storyData)
    {
        StoriesList.Add(storyData);
    }

    public void DeleteStory(string title, string author)
    {
        StoriesList.Remove(FindUniqueStory(title, author));
    }

    public List<StoryData> GetStories()
    {
        return StoriesList;
    }

    public void ChangeTitleAuthorGenre(string oldTitle, string newTitle, string oldAuthor, string newAuthor, string newGenre)
    {
        StoryData tempStoryData = FindUniqueStory(oldTitle, oldAuthor);
        tempStoryData.Title = newTitle;
        tempStoryData.Author = newAuthor;
        tempStoryData.Genre = newGenre;
    }

    //Returns true if the author title pair is unique
    public bool IsUniqueStory(string title, string author)
    {
        List<StoryData> storiesByAuthor = GetStoriesByAuthor(author);

        foreach (var storyByAuthor in storiesByAuthor)
        {
            if (storyByAuthor.Title == title)
            {
                return false;
            }
        }

        return true;
    }

    public StoryData FindUniqueStory(string title, string author)
    {
        List<StoryData> storiesByAuthor = GetStoriesByAuthor(author);

        int i;
        for (i = 0; i < storiesByAuthor.Count; i++)
        {
            if (storiesByAuthor[i].Title == title)
            {
                return storiesByAuthor[i];
            }
        }

        return null;
    }

    //Gets a list of all stories created by a given author
    public List<StoryData> GetStoriesByAuthor(string author)
    {
        List<StoryData> storiesByAuthor = new List<StoryData>();

        foreach (var story in StoriesList)
        {
            if (story.Author == author)
            {
                storiesByAuthor.Add(story);
            }
        }

        return storiesByAuthor;
    }
}