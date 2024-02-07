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
    public void saveMap2(Player p,MapGame map)
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
                    write.WriteLine(p.toString());

                    /*   write.WriteLine(p.getPlayerName());
                       write.WriteLine(p.getCurrentCharacter().getName());
                       write.WriteLine(p.getCurrentCharacter().getLife());
                       write.WriteLine(p.getCurrentCharacter().getLifeMax());
                       write.WriteLine(p.getCurrentCharacter().getMagicPoint());
                       write.WriteLine(p.getCurrentCharacter().getMagicPointMax());
                       write.WriteLine(p.getCurrentCharacter().getAtkStat());
                       write.WriteLine(p.getCurrentCharacter().getDefStat());
                       write.WriteLine(p.getCurrentCharacter().getLevel());
                       write.WriteLine(p.getCurrentCharacter().getPositionX());
                       write.WriteLine(p.getCurrentCharacter().getPositionX());
                       write.WriteLine(p.getCurrentCharacter().getPosition());
                       write.WriteLine(p.getCurrentCharacter().getRepresentation());
                           write.WriteLine("namecomp:"+p.getCurrentCharacter().getAtkList().ElementAt<Competence>(0).GetNameCompetence());

                       for (int i=0;i< p.getCurrentCharacter().getAtkList().Count();i++)
                       {
                           write.WriteLine("namecomp:"+p.getCurrentCharacter().getAtkList().ElementAt<Competence>(i).GetNameCompetence());
                           write.WriteLine("levelcomp:" + p.getCurrentCharacter().getAtkList().ElementAt<Competence>(i).GetLevelComp());
                           write.WriteLine("int type:" + p.getCurrentCharacter().getAtkList().ElementAt<Competence>(i).getTypePersoComp_Int());

                       }*/


                    for (int i = 0; i < map.size(); i++)
                    {
                        write.WriteLine(map.getElementMap(i));
                    }
                    write.WriteLine(map.getNbLigne());
                    write.WriteLine(map.getNbColonne());

                }
            }
            Console.WriteLine("\nLa carte a été sauvegardée avec succès.");
        }
        catch (Exception e)
        {
            Console.WriteLine("\nUne erreur s'est produite lors de la sauvegarde de la carte : " + e.Message);
        }
    }


    public void saveCharacter(string id_player) { }
    public void saveObject(string id_player) { }
    public void saveStatPlayer(string id_player) { }

    public void saveToJson(Player p, MapGame map)
    {

        string json = "{" +
            "\n  " + "\"Player\": {" +
                  "\n\t\t<\t" + "\"currentPerso\": {" +
                  "\n\t\t<\t" + "\"activer_perso\": " +
            "\n  " + "\"MapGame\":{" +
                      "\n\t   " + "ligne: " + map.getNbLigne() + "," +
                      "\n\t   " + "colonne: " + map.getNbColonne() + "," +
                      "\n\t   " + "field: " + map.getField() + "," +
                      "\n\t   " + "MapAscii: ";
        for (int i = 0; i < map.size(); i++)
        {
            json += map.getElementMap(i);
        }
        json += "\n  \t   }\n}";

        string cheminFichier = "Sauvegarde\\" + p.getPlayerName() + ".json";

        try
        {
            // Écrire le contenu JSON dans un fichier
            File.WriteAllText(cheminFichier, json, Encoding.UTF8);
            Console.WriteLine("Fichier JSON créé avec succès.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
        }
    }







    public void saveToJson2()
    {
        // Création de l'objet JSON sous forme de chaîne
        string json = @"{
            ""personne"": {
                ""nom"": ""Doe"",
                ""prenom"": ""John"",
                ""age"": 30,
                ""adresse"": {
                    ""rue"": ""123 Rue Principale"",
                    ""ville"": ""Ville"",
                    ""pays"": ""Pays""
                },
                ""contacts"": [
                    {
                        ""type"": ""email"",
                        ""valeur"": ""john.doe@example.com""
                    },
                    {
                        ""type"": ""téléphone"",
                        ""valeur"": ""123-456-7890""
                    }
                ]
            }
        }";

        // Chemin du fichier JSON
        string cheminFichier = "exemple.json";

        try
        {
            // Écrire le contenu JSON dans un fichier
            File.WriteAllText(cheminFichier, json, Encoding.UTF8);
            Console.WriteLine("Fichier JSON créé avec succès.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
        }
    }
}