using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReadData : MonoBehaviour
{
    public TextAsset data_file;

    void Start()
    {

        Load(data_file);
        // Example: Debug.Log("2006 European Immigrants " + (Convert.ToInt32(Find_Year("2006").BornEurope) / 10000));
    }

    public class Row
    {
        public string Date;
        public string Time;
        public string Color;
        public string Shape;
        public string Rating;

    }

    List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.Date = grid[i][0];
            row.Time = grid[i][1];
            row.Color = grid[i][2];
            row.Shape = grid[i][3];
            row.Rating = grid[i][4];

            rowList.Add(row);
        }
        isLoaded = true;
    }

    public int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public Row Find_Date(string find)
    {
        return rowList.Find(x => x.Date == find);
    }
    public List<Row> FindAll_Date(string find)
    {
        return rowList.FindAll(x => x.Date == find);
    }
    public Row Find_Time(string find)
    {
        return rowList.Find(x => x.Time == find);
    }
    public List<Row> FindAll_Time(string find)
    {
        return rowList.FindAll(x => x.Time== find);
    }
    public Row Find_Color(string find)
    {
        return rowList.Find(x => x.Color == find);
    }
    public List<Row> FindAll_Color(string find)
    {
        return rowList.FindAll(x => x.Color == find);
    }
    public Row Find_Shape(string find)
    {
        return rowList.Find(x => x.Shape == find);
    }
    public List<Row> FindAll_Shape(string find)
    {
        return rowList.FindAll(x => x.Shape == find);
    }
    public Row Find_Rating(string find)
    {
        return rowList.Find(x => x.Rating == find);
    }
    public List<Row> FindAll_Rating(string find)
    {
        return rowList.FindAll(x => x.Rating == find);
    }
}