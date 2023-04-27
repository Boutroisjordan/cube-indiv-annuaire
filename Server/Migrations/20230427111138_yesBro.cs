using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class yesBro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ressources humaines" },
                    { 2, "Informatique" },
                    { 3, "Comptabilité" },
                    { 4, "Production" },
                    { 5, "Accueil" },
                    { 6, "Commercial" }
                });

            migrationBuilder.InsertData(
                table: "Site",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Paris" },
                    { 2, "Toulouse" },
                    { 3, "Lille" },
                    { 4, "Nantes" },
                    { 5, "Nice" }
                });

            migrationBuilder.InsertData(
                table: "Salariers",
                columns: new[] { "Id", "email", "first_name", "fixPhone", "last_name", "portablePhone", "serviceId", "siteId" },
                values: new object[,]
                {
                    { 1, "Lucien_Pierre32@hotmail.fr", "Victoire", "+33 272941070", "Prevost", "+33 224650461", 1, 1 },
                    { 2, "Bastien28@yahoo.fr", "Vinciane", "+33 378159094", "Berger", "+33 768104368", 4, 4 },
                    { 3, "Timothee89@yahoo.fr", "Amalthée", "0302407841", "Rodriguez", "+33 435117296", 6, 1 },
                    { 4, "Clio_Muller@hotmail.fr", "Scholastique", "+33 759113854", "Jean", "+33 233788428", 5, 5 },
                    { 5, "Auguste94@yahoo.fr", "Christine", "+33 163606440", "Adam", "+33 318503647", 4, 5 },
                    { 6, "Zephirin.Muller91@yahoo.fr", "Jason", "0528202154", "Guillaume", "+33 792212062", 6, 2 },
                    { 7, "Stephane_Louis@hotmail.fr", "Emmelie", "+33 159399200", "Caron", "+33 282455437", 2, 5 },
                    { 8, "Abeline36@gmail.com", "Édouard", "+33 492906916", "Philippe", "+33 282415461", 2, 5 },
                    { 9, "Flodoard_Gaillard@hotmail.fr", "Fortunée", "0631108938", "Lambert", "0737974090", 2, 4 },
                    { 10, "Bruno94@hotmail.fr", "Aleaume", "0714922753", "Royer", "0576963367", 2, 5 },
                    { 11, "Camille.Colin@hotmail.fr", "Andoche", "+33 782029510", "Chevalier", "0323996219", 6, 5 },
                    { 12, "Segolene_Robin@hotmail.fr", "Pécine", "+33 245574957", "Olivier", "0258018107", 6, 3 },
                    { 13, "Isabelle_Robin@yahoo.fr", "Léonie", "0653940324", "Duval", "+33 278730587", 5, 2 },
                    { 14, "Ascelin20@hotmail.fr", "Athalie", "+33 163498997", "Lefevre", "+33 363809211", 6, 1 },
                    { 15, "Rosalie.Marchal62@yahoo.fr", "Girart", "+33 719710432", "Lopez", "0334926346", 6, 3 },
                    { 16, "Gustave_Garcia@hotmail.fr", "Anne", "0783737796", "Louis", "0402779865", 5, 1 },
                    { 17, "Isabeau_Marchal@gmail.com", "Séraphin", "0409463578", "Fabre", "+33 361290684", 6, 2 },
                    { 18, "Armance33@hotmail.fr", "Gustavine", "+33 325989845", "Philippe", "+33 798046741", 5, 5 },
                    { 19, "Titien.Benoit45@yahoo.fr", "Denise", "0265225185", "Olivier", "+33 396326188", 3, 2 },
                    { 20, "Eliane98@gmail.com", "Balthazar", "0120993470", "Riviere", "+33 664982874", 4, 4 },
                    { 21, "Elie53@hotmail.fr", "Cléry", "0778549945", "Garcia", "0452258232", 1, 2 },
                    { 22, "Edith_Laine@yahoo.fr", "Richard", "+33 744490632", "Perez", "0223910259", 1, 2 },
                    { 23, "Constant_Lucas@gmail.com", "Baudouin", "0758883124", "Pierre", "+33 434134134", 6, 5 },
                    { 24, "Astride.Leroux@yahoo.fr", "Didier", "0621069437", "Colin", "0262189885", 6, 4 },
                    { 25, "Thibault17@hotmail.fr", "Azalée", "+33 249323843", "Lopez", "+33 258618884", 3, 3 },
                    { 26, "Samuel.Leclercq69@yahoo.fr", "Céline", "0356740384", "Lemaire", "+33 579137508", 1, 3 },
                    { 27, "Fabrice.Adam@yahoo.fr", "Alcyone", "+33 666303789", "Picard", "0469410832", 1, 3 },
                    { 28, "Amaliane87@gmail.com", "Philémon", "+33 473002120", "Paris", "0164551752", 2, 5 },
                    { 29, "Lambert.Sanchez@hotmail.fr", "Carine", "+33 501392777", "Arnaud", "0382452057", 1, 2 },
                    { 30, "Jonathan.Baron22@gmail.com", "Francisque", "+33 413533719", "Julien", "0408814555", 5, 4 },
                    { 31, "Benedicte.Julien@yahoo.fr", "Céleste", "0193032138", "Fournier", "0127255871", 1, 3 },
                    { 32, "Cecile93@yahoo.fr", "Octave", "+33 102953486", "Royer", "+33 725057485", 6, 4 },
                    { 33, "Berard.Mercier@yahoo.fr", "Lucille", "0490026055", "Fabre", "+33 650311892", 2, 4 },
                    { 34, "Oury_Perrin38@hotmail.fr", "Raoul", "+33 467328805", "Olivier", "0122382657", 1, 5 },
                    { 35, "Valentine.Dubois@hotmail.fr", "Léa", "0612323513", "Da silva", "0796199981", 1, 1 },
                    { 36, "Iseult3@yahoo.fr", "Marceau", "+33 562316891", "Meunier", "0544774605", 1, 1 },
                    { 37, "Brigitte.Marchand@hotmail.fr", "Vincent", "0632030213", "Riviere", "0326631931", 4, 3 },
                    { 38, "Emeric_Martin@yahoo.fr", "Timoléon", "0681231101", "Gaillard", "+33 111468402", 2, 3 },
                    { 39, "Christelle92@hotmail.fr", "Blaise", "+33 447698669", "Clement", "0415695347", 4, 1 },
                    { 40, "Briac_Jacquet79@yahoo.fr", "Célestine", "+33 158808761", "Marie", "0616275557", 4, 4 },
                    { 41, "Isidore.Dubois13@hotmail.fr", "Audrey", "0775475504", "Renaud", "+33 776543857", 2, 5 },
                    { 42, "Agrippin98@gmail.com", "Adelin", "0661037704", "Leclercq", "+33 714350202", 3, 2 },
                    { 43, "Emile38@hotmail.fr", "Dorian", "0333458889", "Roger", "+33 760645839", 6, 5 },
                    { 44, "Clement.Denis11@yahoo.fr", "Abelin", "0531922330", "Roux", "+33 367829540", 6, 3 },
                    { 45, "Reybaud.Nguyen@gmail.com", "Anémone", "+33 789547626", "Leclerc", "+33 366006181", 2, 5 },
                    { 46, "Tristan_Fernandez44@hotmail.fr", "Annonciade", "0391040399", "Rodriguez", "0650171660", 3, 4 },
                    { 47, "Maurice_Fournier@yahoo.fr", "Childebert", "0290249386", "Breton", "0465188357", 1, 5 },
                    { 48, "Emmanuel.Olivier22@yahoo.fr", "Célien", "0622072308", "Denis", "0280263402", 4, 2 },
                    { 49, "Ancelin.Sanchez45@gmail.com", "Oury", "0743643147", "Martin", "+33 291686825", 5, 1 },
                    { 50, "Lucienne_Morel25@gmail.com", "Aude", "+33 648792989", "David", "0253973286", 1, 2 },
                    { 51, "Trajan_Collet44@hotmail.fr", "Annette", "+33 206860851", "Renault", "+33 332133748", 1, 4 },
                    { 52, "Mallaury12@hotmail.fr", "Jocelyn", "0497393037", "Carpentier", "0398025235", 1, 3 },
                    { 53, "Guerin.Marchal@gmail.com", "Andéol", "+33 273973551", "Roy", "0692376929", 5, 3 },
                    { 54, "Honore.Renard@hotmail.fr", "Corentin", "0228041138", "Joly", "0690570809", 6, 2 },
                    { 55, "Violette46@gmail.com", "Émérencie", "+33 225575591", "Dupont", "0616324628", 2, 2 },
                    { 56, "Penelope57@gmail.com", "Clarence", "+33 593919368", "Dufour", "+33 473977651", 2, 1 },
                    { 57, "Aglae4@hotmail.fr", "Aldric", "0719427966", "Roche", "0101123968", 2, 3 },
                    { 58, "Constant.Brunet42@gmail.com", "Macaire", "+33 105203052", "Joly", "0186583276", 5, 4 },
                    { 59, "Apollinaire_Fleury@gmail.com", "Rachel", "+33 797749542", "Barre", "0101896279", 3, 5 },
                    { 60, "Caroline_Dumont@gmail.com", "Conception", "0118514982", "Giraud", "+33 631154559", 1, 2 },
                    { 61, "Alexandrine29@gmail.com", "Fulbert", "0677759751", "Dupuis", "+33 514059833", 6, 3 },
                    { 62, "Absalon_Royer48@hotmail.fr", "Alpinien", "+33 464266584", "Leclercq", "+33 116748033", 3, 2 },
                    { 63, "Thierry_Gerard86@hotmail.fr", "Camille", "0239819684", "Blanchard", "+33 552875022", 3, 1 },
                    { 64, "Laurent_Barre@yahoo.fr", "Célien", "0135029722", "Lefebvre", "0387896383", 6, 3 },
                    { 65, "Arnaud_Garcia49@yahoo.fr", "Laurent", "0729751136", "Morin", "+33 633052893", 1, 4 },
                    { 66, "Adhemar.Dufour43@hotmail.fr", "Nathanaël", "0256808321", "Renard", "0241336972", 1, 4 },
                    { 67, "Alliaume.Roy37@gmail.com", "Abélard", "+33 707300801", "Renaud", "0524529241", 2, 4 },
                    { 68, "Agapet62@gmail.com", "Georgette", "+33 762277370", "Da silva", "0669968747", 6, 1 },
                    { 69, "Gabin_Fleury9@hotmail.fr", "Anastase", "+33 459493979", "Thomas", "0187190164", 6, 3 },
                    { 70, "Suzon.Michel@gmail.com", "Cécile", "0577122831", "Rodriguez", "+33 467480596", 4, 4 },
                    { 71, "Didier_Bonnet@gmail.com", "Gabrielle", "0151392065", "Garcia", "0588313621", 4, 3 },
                    { 72, "Elie_Paul32@hotmail.fr", "Maxence", "+33 239052768", "Adam", "0426834012", 3, 4 },
                    { 73, "Artheme12@hotmail.fr", "Raymond", "+33 473705043", "Simon", "+33 219679098", 6, 2 },
                    { 74, "Helier61@hotmail.fr", "Juste", "+33 301497384", "Sanchez", "0385742951", 6, 3 },
                    { 75, "Gilles.Schneider63@gmail.com", "Gilbert", "0517356991", "Boyer", "0726710848", 3, 2 },
                    { 76, "Zoe35@hotmail.fr", "Nicéphore", "+33 155226683", "Nguyen", "0520181746", 5, 4 },
                    { 77, "Rodrigue.Caron@gmail.com", "Fabien", "0238350871", "Morel", "0153450974", 5, 4 },
                    { 78, "Henri69@gmail.com", "Philippe", "0372213986", "Guerin", "0115685581", 2, 4 },
                    { 79, "Wandrille_Maillard4@yahoo.fr", "Maurice", "0285971440", "Vidal", "0574849359", 2, 3 },
                    { 80, "Fantin57@hotmail.fr", "Laurane", "0474983188", "Huet", "+33 274051937", 2, 4 },
                    { 81, "Rachel_Vincent@hotmail.fr", "Martial", "0526301584", "Berger", "+33 361735590", 3, 2 },
                    { 82, "Delphin.Noel@yahoo.fr", "Germaine", "0117012158", "Sanchez", "0232804607", 1, 2 },
                    { 83, "Beuve.Baron39@hotmail.fr", "Jeanne", "0789956290", "Duval", "0465915253", 1, 2 },
                    { 84, "Patrice_Laurent18@hotmail.fr", "Viviane", "+33 382803197", "Brun", "+33 120312170", 4, 5 },
                    { 85, "Joseph72@hotmail.fr", "Paulette", "+33 626158576", "Robert", "0173680461", 5, 4 },
                    { 86, "Azeline19@gmail.com", "Nicole", "0697381842", "Fontaine", "0497893381", 4, 2 },
                    { 87, "Elzear.Arnaud35@yahoo.fr", "Gilbert", "0536710708", "Julien", "0305183856", 6, 1 },
                    { 88, "Bruno_Denis62@yahoo.fr", "Lothaire", "0258388448", "Fabre", "0536329195", 6, 2 },
                    { 89, "Aimee.Dupont@hotmail.fr", "Alcime", "0533326522", "Paris", "+33 333588441", 2, 5 },
                    { 90, "Adalric95@gmail.com", "Marine", "+33 597642331", "Renard", "+33 237471272", 6, 1 },
                    { 91, "Adelie65@yahoo.fr", "Gabin", "0599068266", "Marchal", "+33 326065535", 2, 4 },
                    { 92, "Philemon.Bertrand54@gmail.com", "Jules", "0375814281", "Marchal", "+33 270892770", 1, 3 },
                    { 93, "Michael.Baron@yahoo.fr", "Gontran", "+33 498687978", "Prevost", "0340377375", 5, 2 },
                    { 94, "Rosalie.Brunet@yahoo.fr", "Séverin", "0425344465", "Leroux", "0614668153", 3, 3 },
                    { 95, "Germain_Philippe25@hotmail.fr", "Alberte", "0490747926", "Leroy", "+33 191890387", 4, 3 },
                    { 96, "Clara.Dumont88@hotmail.fr", "Melchior", "+33 799670848", "Adam", "0771455524", 5, 5 },
                    { 97, "Lorraine.Boyer@gmail.com", "Tonnin", "+33 322962703", "Duval", "0213617970", 4, 2 },
                    { 98, "Gerbert23@hotmail.fr", "Mathilde", "+33 313104214", "Pierre", "+33 711945875", 1, 2 },
                    { 99, "Trajan.Boyer60@gmail.com", "Hélène", "+33 724239100", "Marchand", "0556468847", 1, 2 },
                    { 100, "Naudet.Fabre@yahoo.fr", "Angélique", "0682792021", "Barbier", "0455629553", 4, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Salariers",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Site",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Site",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Site",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Site",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Site",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
