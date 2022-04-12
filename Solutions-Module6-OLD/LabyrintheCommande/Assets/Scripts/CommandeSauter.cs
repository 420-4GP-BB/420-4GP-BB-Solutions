using UnityEngine;

public class CommandeSauter : ICommand
{
        private MouvementCharacter sujet;
        
        public CommandeSauter(MouvementCharacter sujet)
        {
                this.sujet = sujet;
        }
        
        public void Executer() 
        {
                sujet.Sauter();
        }
}
