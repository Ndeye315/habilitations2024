using Microsoft.VisualStudio.TestTools.UnitTesting;
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
namespace habilitations2024.model.Tests
{
    [TestClass()]
    public class DeveloppeurTests
    {
        private const int id = 21;
        private const string nom = "Dupont";
        private const string prenom = "Alain";
        private const string tel = "666";
        private const string mail = "alain.dupond@domain.fr";
        private static readonly Profil profil = new Profil(5, "admin");
        private static readonly Developpeur dev = new Developpeur(id, nom, prenom, tel, mail, profil);

        [TestMethod()]
        public void DeveloppeurTest()
        {
            Assert.AreEqual(id, dev.Iddeveloppeur, "devrait réussir : id valorisé");
            Assert.AreEqual(nom, dev.Nom, "devrait réussir : nom valorisé");
            Assert.AreEqual(prenom, dev.Prenom, "devrait réussir : prenom valorisé");
            Assert.AreEqual(tel, dev.Tel, "devrait réussir : tel valorisé");
            Assert.AreEqual(mail, dev.Mail, "devrait réussir : mail valorisé");
            Assert.AreEqual(profil, dev.Profil, "devrait réussir : profil valorisé");
        }
    }
}
