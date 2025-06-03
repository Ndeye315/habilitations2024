
TestMethod]
public void TestGetLesDeveloppeursAvecProfil()
{
    // Prévoir que la base contient 2 développeurs avec le profil "senior"
    var liste = DeveloppeurAccess.GetLesDeveloppeurs("senior");
    Assert.AreEqual(2, liste.Count);
}

[TestMethod]
public void TestGetLesDeveloppeursSansFiltre()
{
    // Prévoir que la base contient 5 développeurs
    var liste = DeveloppeurAccess.GetLesDeveloppeurs();
    Assert.AreEqual(5, liste.Count);
}
