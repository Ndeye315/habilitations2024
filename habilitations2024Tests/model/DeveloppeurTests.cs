public static List<Developpeur> GetLesDeveloppeurs(string profil = null)
{
    List<Developpeur> lesDeveloppeurs = new List<Developpeur>();
    string req = "SELECT * FROM developpeur";
    if (!string.IsNullOrEmpty(profil))
    {
        req += " WHERE profil = @profil";
    }
    SqlCommand cmd = new SqlCommand(req, ConnexionSql.Connection);
    if (!string.IsNullOrEmpty(profil))
    {
        cmd.Parameters.AddWithValue("@profil", profil);
    }
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Developpeur d = new Developpeur(
            int.Parse(reader["iddev"].ToString()),
            reader["nom"].ToString(),
            reader["prenom"].ToString(),
            reader["profil"].ToString()
        );
        lesDeveloppeurs.Add(d);
    }
    reader.Close();
    return lesDeveloppeurs;
}
