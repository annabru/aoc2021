namespace aoc2021.Day10;
public class Chunk
{
    private List<Chunk> chunks;
    public ChunkType Type { get; private set; }
    private ChunkType endType;

    public bool IsCorrupted
    {
        get => Type != endType && endType != ChunkType.missing;
    }

    public bool IsIncomplete
    {
        get => endType == ChunkType.missing;
    }
    public int Length 
    {
        get => chunks.Count;
    }
    public bool CorruptedChildren
    {
        get => chunks.Any(x => x.IsOrContainsCorrupted);
    }
    public bool IsOrContainsCorrupted {
        get => IsCorrupted || CorruptedChildren;
    }

    public bool IncompleteChildren
    {
        get => chunks.Any(x => x.IsOrContainsIncompletes);
    }
    public bool IsOrContainsIncompletes
    {
        get => IsIncomplete || IncompleteChildren;
    }



    public Chunk(string stringChunk)
    {
        this.Type = ChunkType.line;
        this.endType = ChunkType.line;
        chunks = new List<Chunk>();
        AddChunks(ref stringChunk, chunks);
    }

    private Chunk(ref string stringChunk)
    {
        this.Type = ParseType(stringChunk.First());
        stringChunk =  stringChunk.Remove(0,1);
        chunks = new List<Chunk>();
        AddChunks(ref stringChunk, chunks);

        if (stringChunk.Count() == 0)
        {
            endType = ChunkType.missing;
        }
        else
        {
            endType = ParseType(stringChunk.First());
            stringChunk =  stringChunk.Remove(0,1);
        }
    }

    public int GetCorruptedScore()
    {
        var res = 0;

        if(this.IsCorrupted)
        {
            res += GetScoreFromChunkType(this.endType);
        }

        if (this.CorruptedChildren)
        {
            res += GetScoreFromChilds();
        }
        return res;
    }

    public long GetCompleteScore()
    {
        if(this.IsOrContainsCorrupted) return 0;
        if( Type == ChunkType.line)
        {
            return GetCompleteScoreChildren();
        }
        else if (this.IncompleteChildren)
        {
            return 5 * GetCompleteScoreChildren() + GetScoreFromMissingChunkType();
        }
        else
        {
            return GetScoreFromMissingChunkType();
        }
    }

    private long GetCompleteScoreChildren()
    {
        long res = 0;
        foreach(Chunk chunk in chunks)
        {
            res += chunk.GetCompleteScore();
        }
        return res;
    }

    private int GetScoreFromMissingChunkType()
    {
        if (!IsIncomplete)
        {
            return 0;
        }
        switch (Type)
        {
            case ChunkType.soft:
                return 1;
            case ChunkType.hard:
                return 2;
            case ChunkType.bird:
                return 3;
            case ChunkType.mouth:
                return 4;
            default: return 0;
        }
    }

    private int GetScoreFromChilds()
    {
        var res = 0;
        foreach(var child in chunks)
        {
            res += child.GetCorruptedScore();
        }
        return res;
    }

    private int GetScoreFromChunkType(ChunkType endType)
    {
        switch (endType)
        {
            case ChunkType.soft:
                return 3;
            case ChunkType.hard:
                return 57;
            case ChunkType.bird:
                return 1197;
            case ChunkType.mouth:
                return 25137;
            default: return 0;
        }
    }

    private void AddChunks(ref string stringChunk, List<Chunk> cs)
    {
        while (stringChunk.Count() > 0 && IsOpen(stringChunk.First()) )
        {
            cs.Add(new Chunk(ref stringChunk));
        }

    }

    private bool IsOpen(char v)
    {
        if (v == '<' || v == '(' || v == '{' || v == '[') return true;
        return false;
    }

    private ChunkType ParseType(char v)
    {
        switch (v)
        {
            case '<':
            case '>':
                return ChunkType.mouth;
            case '{':
            case '}':
                return ChunkType.bird;
            case '(':
            case ')':
                return ChunkType.soft;
            case '[':
            case ']':
                return ChunkType.hard;
            default: return ChunkType.wrong;
        }
    }
}

public enum ChunkType
{
    wrong,
    missing,
    line,

    soft,
    bird,
    mouth,
    hard
}