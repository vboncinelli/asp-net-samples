using System.Text.Json;
using text_adventure.mvc.Models;

namespace text_adventure.mvc.Services
{
    public class GameService : IGameService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public GameService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public GameState LoadGameState()
        {
            var request = _contextAccessor.HttpContext?.Request;

            var gameState = new GameState();

            // Load current room from cookies
            var currentRoom = request?.Cookies["CurrentRoom"];

            if (!string.IsNullOrEmpty(currentRoom))
            {
                gameState.CurrentRoom = currentRoom;
            }

            // Load inventory from cookies
            var inventoryJson = request?.Cookies["Inventory"];

            if (!string.IsNullOrEmpty(inventoryJson))
            {
                gameState.Inventory = JsonSerializer.Deserialize<List<string>>(inventoryJson) ?? [];
            }

            return gameState;
        }

        public string ProcessPlayerCommand(string command, GameState gameState)
        {
            var room = gameState.Rooms[gameState.CurrentRoom];

            if (command == "inventory")
            {
                return gameState.Inventory.Count > 0 ? $"Inventory: {string.Join(", ", gameState.Inventory)}" : "Your inventory is empty.";
            }

            if (command == "look")
            {
                string itemDescription = room.Items.Count > 0 ? $"You see: {string.Join(", ", room.Items)}." : "There is nothing of interest here.";
                var exits = room.Commands
                                .Where(cmd => cmd.Key.StartsWith("go "))
                                .Select(cmd => cmd.Key.Split(" ")[1])
                                .ToList();
                string exitDescription = exits.Count > 0 ? $"Exits: {string.Join(", ", exits)}." : "There are no visible exits here.";
                return $"{itemDescription} {exitDescription}";
            }

            if (command.StartsWith("take"))
            {
                var item = command.Substring(5);
                if (room.Items.Contains(item))
                {
                    gameState.Inventory.Add(item);
                    room.Items.Remove(item);
                    return $"You take the {item}.";
                }
                return $"There is no {item} here.";
            }

            if (command.StartsWith("drop"))
            {
                var item = command.Substring(5);
                if (gameState.Inventory.Contains(item))
                {
                    gameState.Inventory.Remove(item);
                    room.Items.Add(item);
                    return $"You drop the {item}.";
                }
                return $"You don't have a {item}.";
            }

            if (room.RoomActions.TryGetValue(command, out var action))
            {
                return action();
            }

            if (room.Commands.TryGetValue(command, out var result))
            {
                if (gameState.Rooms.ContainsKey(result))
                {
                    gameState.CurrentRoom = result;
                    return gameState.Rooms[result].Description;
                }
                return result;
            }

            return $"Unknown command: {command}";
        }

        // Save GameState to cookies
        public void SaveGameState(GameState gameState)
        {
            var response = _contextAccessor.HttpContext?.Response;

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,  // Prevents JavaScript access
                Secure = true,    // Ensures cookies are only sent over HTTPS
                SameSite = SameSiteMode.Strict,  // Prevents cookies from being sent with cross-site requests
                Expires = DateTimeOffset.Now.AddDays(1)
            };

            // Save current room to cookies
            response?.Cookies.Append("CurrentRoom", gameState.CurrentRoom, cookieOptions);

            // Save inventory to cookies (serialize to JSON)
            var inventoryJson = JsonSerializer.Serialize(gameState.Inventory);

            response?.Cookies.Append("Inventory", inventoryJson, cookieOptions);
        }
    }
}
