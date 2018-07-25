using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer{

    private string _image;
    private string _result;

    public string Image
    {
        get
        {
            return _image;
        }
        set
        {
            _image = value;
        }
    }

    public string Result
    {
        get
        {
            return _result;
        }
        set
        {
            _result = value;
        }
    }


    public Answer(string image, string result)
    {
        _image = image;
        _result = result;
    }
}
