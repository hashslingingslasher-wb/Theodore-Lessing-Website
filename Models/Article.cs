public class Article
{
    public string ID {get; set;}
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Aside { get; set; }
    public string? FileName { get; set; }

    public Article (){
        ID = Guid.NewGuid().ToString("N");
    }
}
