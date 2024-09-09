namespace Data.Entities;

public class Material : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public int? Duration { get; set; }

    public int LectureId { get; set; }
    public Lecture? Lecture { get; set; }

    public override string ToString()
    {
        return Name;
    }
}