using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day12;
public class CaveSystem
{
    private Dictionary<string, Cave> caves = new Dictionary<string, Cave>();
    private List<List<Cave>> paths = new List<List<Cave>>();

    public List<List<Cave>> Paths { get =>  paths; }

    public Dictionary<string, Cave> Caves { get => caves; }

    public CaveSystem(List<string> lines, bool withExtraStop)
    {
        AddCaves(lines);
        CalculatePaths(withExtraStop);
    }

    private void AddCaves(List<string> lines)
    {
        foreach(var line in lines)
        {
            AddCavesWithNeighbour(line);
        }
    }

    private void AddCavesWithNeighbour(string line)
    {
        var caves = line.Split('-');
        var fromCaveId = caves[0];
        var toCaveId = caves[1];

        Cave fromCave;
        Cave toCave;

        if (!this.caves.TryGetValue(fromCaveId, out fromCave))
        {
            fromCave = CreateCave(fromCaveId);
            this.caves.Add(fromCaveId, fromCave);
        }
        if (!this.caves.TryGetValue(toCaveId, out toCave)) 
        {
            toCave = CreateCave(toCaveId);
            this.caves.Add(toCaveId, toCave);
        }

        AddNeighbours(toCave, fromCave);
    }

    private void AddNeighbours(Cave toCave, Cave fromCave)
    {
        toCave.AddNeighbour(fromCave);
        fromCave.AddNeighbour(toCave);
    }

    private Cave CreateCave(string caveId)
    {
        Cave cave;
        if (caveId.All(c => char.IsUpper(c)))
        {
            cave = new BigCave(caveId);
        }
        else
        {
            cave = new SmallCave(caveId);
        }
        return cave;
    }

    private void CalculatePaths(bool withExtraStop )
    {
        var caves = Caves;
        var extraStop = 0;

        if(withExtraStop) extraStop++;

        CalculatePaths("start", caves, new List<Cave>(), extraStop);
    }

    private void CalculatePaths(string currentCaveId, Dictionary<string, Cave> caves, List<Cave> pathSoFar, int extraStop)
    {
        var currentCave = caves[currentCaveId];

        currentCave.Visited = true;
        pathSoFar.Add(currentCave);
        if(currentCaveId == "end")
        {
            paths.Add(pathSoFar);
            return;
        }
        
        foreach(var neighbour in currentCave.adjecentCaves)
        {
            if (neighbour.Id != "start" && neighbour.Visited && extraStop > 0)
            {
                CalculatePaths(neighbour.Id, caves, pathSoFar, extraStop-1);
                pathSoFar.RemoveAt(pathSoFar.Count - 1);
            }
            else if (!neighbour.Visited)
            {
                CalculatePaths(neighbour.Id, caves, pathSoFar, extraStop);
                neighbour.Visited = false;
                pathSoFar.RemoveAt(pathSoFar.Count - 1);
            }
        }
    }
}

public abstract class Cave
{
    public virtual bool Visited { get; set; }
    public string Id { get; set; }
    public HashSet<Cave> adjecentCaves = new HashSet<Cave>();

    public void AddNeighbour(Cave neighbour)
    {
        adjecentCaves.Add(neighbour);
    }
}

public class SmallCave : Cave
{
    public SmallCave(string id)
    {
        Visited = false;
        Id = id;
    }
}

public class BigCave : Cave
{

    public override bool Visited { get => false; }

    public BigCave(string id)
    {
        Id = id;
    }
}