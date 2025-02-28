namespace tb_techtales_api.Models
{
    public class Skill
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Technology { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; //jag tänkte ha backend, frontend, db, testning, cloud/övrigt och så ska man kunna kategorisera efter kategori
        public int YearsOfExperience { get; set; }
        public string Level { get; set; } = string.Empty;
    }
}

//Tech Novice:Nybörjare i techvärlden, men ivrig att lära mig och utforska! Har pluggat grunderna och byggt några små projekt för att förstå hur allt fungerar
//Code Explorer:Utforskar teknologier och ständigt på jakt efter nya insikter. Jag har jobbat med teknologin på en grundläggande nivå och är redo att ta mig an större projekt.
//Tech Enthusiast: jag har en stark förståelse för teknologin och använder den för att bygga robusta lösningar. Jag har praktisk erfarenhet av att lösa problem och skapa användbara applikationer.
//Code Ninja:Behärskar teknologin som en riktig mästare! Jag skriver ren och effektiv kod, optimerar prestanda och skapar lösningar för avancerade problem. Jag gillar att ta mig an utmaningar och hitta smarta lösningar.
//Tech Wizard: En fulländad magiker när det gäller denna teknik. Jag har djup förståelse för alla nyanser och kan skapa imponerande lösningar på en nivå som får folk att tappa hakan. Jag har lett projekt och skapat innovationer som har påverkat hela team.
