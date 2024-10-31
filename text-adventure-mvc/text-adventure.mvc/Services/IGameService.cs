using text_adventure.mvc.Models;

namespace text_adventure.mvc.Services
{
    public interface IGameService
    {
        GameState LoadGameState();

        string ProcessPlayerCommand(string v, GameState gameState);

        void SaveGameState(GameState gameState);
    }
}
