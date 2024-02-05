using System;
using System.IO;
using System.Text;

public class Sauvegarde
{
    private string file_save; //fichier de sauvegarde des stats, elle aura le meme nom que l'id du joueur + "save.txt"
    private string file_charater;
    private string file_object;
    private string file_map;

    //private int hashcode;

    public Sauvegarde() {
        file_save = "";
        file_charater ="";
        file_object = "";
        file_map = "";
    }
    public Sauvegarde(string id_player)
    {
        file_save = ".\\Sauvegarde\\" + id_player+"_saveStats.txt";
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
    public void saveMap(MapGame map) {
        try
        { 
           using (FileStream fs = File.Create(file_map)) //creation de flux de fichier
           {     
              using (StreamWriter write = new StreamWriter(file_map)) //creation d'un stream pour ecrire dans file_map
              {
                  //test si le fichier existe
                  if (File.Exists(file_map))
                  {
                     //ecrit la map dans la 1er ligne
                     write.WriteLine(map.getMap());
                     //ecrit le nombre de ligne de la map
                     write.WriteLine(map.getNbLigne());
                     //ecrit le nombre de ligne de la map
                     write.WriteLine(map.getNbColonne());
                     //fermeture du flot d'ecriture
                     write.Close();
                     //fermeture du fichier/flot de fichier
                     fs.Close();
                  }
                  else
                  {
                     //ecrit la map dans la 1er ligne
                     write.WriteLine(map.getMap());
                     //ecrit le nombre de ligne de la map
                     write.WriteLine(map.getNbLigne());
                     //ecrit le nombre de ligne de la map
                     write.WriteLine(map.getNbColonne());
                     //fermeture du flot d'ecriture
                     write.Close();
                     //fermeture du fichier/flot de fichier
                     fs.Close();
                    }
              }

            }

           
         
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }

   

public void saveMap2(MapGame map)
{
    try
    {
        // Utilisation de FileMode.Create pour créer un nouveau fichier ou écraser s'il existe déjà
        using (FileStream fs = File.Open(file_map, FileMode.Create))
        {
            // Utilisation de StreamWriter avec le flux de fichier
            using (StreamWriter write = new StreamWriter(fs))
            {
                // Écriture des données dans le fichier
                for(int i = 0; i < map.size(); i++)
                {
                   write.WriteLine(map.getElementMap(i));
                }
                write.WriteLine(map.getNbLigne());
                write.WriteLine(map.getNbColonne());

            }
        }
        Console.WriteLine("La carte a été sauvegardée avec succès.");
    }
    catch (Exception e)
    {
        Console.WriteLine("Une erreur s'est produite lors de la sauvegarde de la carte : " + e.Message);
    }
}


    public void saveCharacter(string id_player) { }
    public void saveObject(string id_player) { }
    public void saveStatPlayer(string id_player) { }


}