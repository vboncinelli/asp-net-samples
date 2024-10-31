namespace text_adventure.mvc.Models;

public class Room
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public Dictionary<string, string> Commands { get; set; } = [];

    public Dictionary<string, Func<string>> RoomActions { get; set; } = [];

    public List<string> Items { get; set; } = [];
}