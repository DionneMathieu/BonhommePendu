using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            Events = new List<GameEvent> { };

            Events.Add(new GuessedLetterEvent(gameData, letter));

            gameData.GuessedLetters.Add(letter);

            bool correct = false;
            //par défault retourne false

            for (int i = 0; i < gameData.Word.Length; i++)
                //passe a traver chaque lettre du mot pour voir si une lettre correspond à la lettre tapé
            {
                if (gameData.HasSameLetterAtIndex(letter, i))
                {
                    correct = true;
                    //retourne vrai pour éviter la logic qui suit
                    Events.Add(new RevealLetterEvent(gameData, letter, i));

                }
            }
            if (!correct)
                //la lettre n'est pas dans le mot si correct est faux
            {
                Events.Add(new WrongGuessEvent(gameData));
            }

        }
    }
}
