using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class KuMonDatabase {

    private string conn = "";
    private IDbConnection dbConn = null;
    private IDbCommand dbcmd = null;
    private string dataBasePath = "KumonSQLite.s3db";
    //private string dataBasePath = "KumonSQLite.s3db";
    //private Text t1;


    public KuMonDatabase()
    {
        //try
        //{
        //    string filePath = Application.persistentDataPath + "/" + dataBasePath;
        //    if (!File.Exists(filePath))
        //    {
        //        WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + dataBasePath);
        //        while (!loadDB.isDone) { }
        //        File.WriteAllBytes(filePath, loadDB.bytes);
        //    }
        //    conn = "URI=file:" + filePath;
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e.ToString());
        //}
        //t1 = text;
        conn = "URI=file:" + Application.dataPath + "/StreamingAssets/KumonSQLite.s3db";
    }

    public Question GetRabdomQuestionByGrade_Level(int grade, int level)
    {
        dbConn = (IDbConnection)new SqliteConnection(conn);
        dbConn.Open();
        dbcmd = dbConn.CreateCommand();
        string sqlQuery = "SELECT * FROM Question WHERE Grade = " + grade + " AND Level = " + level + " ORDER BY RANDOM() LIMIT 1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        int id = reader.GetInt32(0);
        string content = reader.GetString(1);
        Question question = new Question(id, content);
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbConn.Close();
        dbConn = null;

        return question;
    }

    public Question GetQuestionByID(int grade, int level, int id)
    {
        try
        {
            dbConn = (IDbConnection)new SqliteConnection(conn);
            dbConn.Open();
            dbcmd = dbConn.CreateCommand();
            string sqlQuery = "SELECT * FROM Question WHERE Grade = " + grade + " AND Level = " + level + " AND ID = " + id;
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Read();
            string content = reader.GetString(1);
            Question question = new Question(id, content);
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbConn.Close();
            dbConn = null;
            return question;
        }
        catch (Exception e)
        {
            //t1.text = e.ToString();
            return null;
        }
    }

    public List<Answer> GetRandomAnswerFollowQuestion(int questionID)
    {
        dbConn = (IDbConnection)new SqliteConnection(conn);
        dbConn.Open();
        dbcmd = dbConn.CreateCommand();
        string sqlQuery = "SELECT * FROM Answer WHERE QUESTION_ID = " + questionID + " ORDER BY RANDOM() LIMIT 4";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        List<Answer> answers = new List<Answer>();
        while (reader.Read())
        {
            string image = reader.GetString(1);
            string result = reader.GetString(2);
            Answer answer = new Answer(image, result);
            answers.Add(answer);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbConn.Close();
        dbConn = null;
        return answers;
    }
}
