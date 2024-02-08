using System;
using System.IO;
using System.Text;
using System.Text.Json;

public class Sauvegarde
{
    private string file_save; //fichier de sauvegarde des stats, elle aura le meme nom que l'id du joueur + "save.txt"
    private string file_charater;
    private string file_object;
    private string file_map;
    //private static int nb_sauvegarde=0;

    //private int hashcode;

    public Sauvegarde()
    {
        file_save = "";
        file_charater = "";
        file_object = "";
        file_map = "";
    }
    public Sauvegarde(string id_player)
    {
        file_save = ".\\Sauvegarde\\" + id_player + "_saveStats.txt";
        file_charater = ".\\Sauvegarde\\" + id_player + "_saveCharacter.txt";
        file_object = ".\\Sauvegarde\\" + id_player + "_saveObject.txt";
        file_map = ".\\Sauvegarde\\" + id_player + "_saveMap.txt";
        //hashcode = file_save.GetHashCode();
        //file_save = file_save +hashcode+ "_save.text";

    }
    /*ecrit dans le fichier file_map la derniere map sur laquelle le joueur etait*
     *ici le mot cles 'using' est utiliser pour liberer les ressources utiliser dans son bloc
     */
    /// <summary>
    /// 
    /// </summary>
    /// <param name="map"></param>
    /// <return> int </return>return> 
    public string saveMap2(Player p, MapGame map)
    {
        string result = "";
        try
        {
            // Utilisation de FileMode.Create pour créer un nouveau fichier ou écraser s'il existe déjà
            using (FileStream fs = File.Open(file_map, FileMode.Create))
            {
                // Utilisation de StreamWriter avec le flux de fichier
                using (StreamWriter write = new StreamWriter(fs))
                {
                    // Écriture des données dans le fichier
                    write.WriteLine(p.toString());
                    for (int i = 0; i < map.size(); i++)
                    {
                        write.WriteLine(map.getElementMap(i));
                    }
                    write.WriteLine(map.getNbLigne());
                    write.WriteLine(map.getNbColonne());

                }
            }
            // Console.WriteLine("\nLa carte a été sauvegardée avec succès.");
            result += "La carte a été sauvegardée avec succès.";
            return result;
        }
        catch (Exception e)
        {
            //Console.WriteLine(result+="\nUne erreur s'est produite lors de la sauvegarde de la carte : " + e.Message);
            result += "Une erreur s'est produite lors de la sauvegarde de la carte : " + e.Message;
            return result;
        }
    }


    public void saveCharacter(string id_player) {/*a implmenter*/ }
    public void saveObject(string id_player) {/*a implmenter*/ }
    public void saveStatPlayer(string id_player) { /*a implmenter*/}

}