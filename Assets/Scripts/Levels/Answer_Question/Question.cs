using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question {

    private int _id;
    private string _content;

    public int ID
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    public string Content
    {
        get
        {
            return _content;
        }
        set
        {
            _content = value;
        }
    }

    public Question(int id, string content)
    {
        _id = id;
        _content = content;
    }
}
