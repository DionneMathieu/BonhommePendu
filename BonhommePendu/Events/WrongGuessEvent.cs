using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois que la lettre n'est pas dans le mot
    public class WrongGuessEvent : GameEvent
    {
        public override string EventType { get { return "WrongGuess"; } }

        // TODO: Compléter
        public WrongGuessEvent(GameData gameData) {
            Events = new List<GameEvent> { };
            //ajout +1 au nombre de mauvaise réponse
            gameData.NbWrongGuesses++;
            //si 6 mauvaise réponses
            if (gameData.NbWrongGuesses >= 6)
            {
                Events.Add(new LoseEvent(gameData));
            }
        }
    }
}
