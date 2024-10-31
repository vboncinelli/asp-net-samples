namespace text_adventure.mvc.Models
{
    public class GameState
    {
        public string CurrentRoom { get; set; } = "start";

        public List<string> Inventory { get; set; } = new List<string>();

        public Dictionary<string, Room> Rooms { get; set; }

        public GameState()
        {
            Rooms = new Dictionary<string, Room>
            {
                {
                    "start", new Room
                    {
                        Name = "Start Room",
                        Description = "You are in a small, dimly lit room. There’s a door to the north.",
                        Commands = new Dictionary<string, string> 
                        {
                            {"go north", "hall"},
                        },
                        Items = new List<string> { "key" }
                    }
                },
                {
                    "hall", new Room
                    {
                        Name = "Hall",
                        Description = "You are in a grand hallway with doors to the east, west, and south.",
                        Commands = new Dictionary<string, string>
                        {
                            {"go east", "library"},
                            {"go west", "kitchen"},
                            {"go south", "start" }
                        }
                    }
                },
                {
                    "library", new Room
                    {
                        Name = "Library",
                        Description = "The library is filled with ancient books. A stick rests on a high shelf.",
                        Commands = new Dictionary<string, string> { {"go west", "hall"} },
                        Items = new List<string> { "stick" }
                    }
                },
                {
                    "kitchen", new Room
                    {
                        Name = "Kitchen",
                        Description = "The kitchen smells of stale food. There's a locked door to the cellar to the south.",
                        Commands = new Dictionary<string, string>
                        {
                            {"go east", "hall"}
                        },
                        Items = new List<string> { "apple" },
                        RoomActions = new Dictionary<string, Func<string>>()
                    }
                },
                {
                    "garden", new Room
                    {
                        Name = "Garden",
                        Description = "A lush garden. You see a shiny object up in a tree, out of reach.",
                        Commands = new Dictionary<string, string> { {"go north", "kitchen"} },
                        RoomActions = new Dictionary<string, Func<string>>()
                    }
                },
                {
                    "cellar", new Room
                    {
                        Name = "Cellar",
                        Description = "A dark, damp cellar with a faint light coming from a corner."
                    }
                }
            };

            // Set up initial puzzle commands that rely on the Rooms dictionary
            Rooms["kitchen"].RoomActions["use key"] = () =>
            {
                Rooms["kitchen"].Commands["go south"] = "cellar";
                return "You unlock the door to the cellar.";
            };

            Rooms["garden"].RoomActions["use stick"] = () =>
            {
                if (Inventory.Contains("stick"))
                {
                    Inventory.Add("ring");
                    return "Using the stick, you retrieve a golden ring from the tree.";
                }
                return "You need something to reach the item in the tree.";
            };
        }
    }
}
