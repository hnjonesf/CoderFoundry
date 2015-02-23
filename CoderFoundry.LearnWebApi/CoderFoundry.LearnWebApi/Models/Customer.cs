using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoderFoundry.LearnWebApi.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public static readonly List<Customer> CustomerData = new List<Customer>(GetCustomers());


        public static Customer[] GetCustomers()
        {
            return
                JsonConvert.DeserializeObject<Customer[]>(
                    "[{\"CustomerID\":\"ALFKI\",\"CompanyName\":\"Alfreds Futterkiste\",\"ContactName\":\"Maria A" +
                    "nders\",\"ContactTitle\":\"Sales Representative\",\"Address\":\"Obere Str. 57\",\"City\":\"B" +
                    "erlin\",\"Region\":null,\"PostalCode\":\"12209\",\"Country\":\"Germany\",\"Phone\":\"030-00743" +
                    "21\",\"Fax\":\"030-0076545\"},{\"CustomerID\":\"ANATR\",\"CompanyName\":\"Ana Trujillo Empar" +
                    "edados y helados\",\"ContactName\":\"Ana Trujillo\",\"ContactTitle\":\"Owner\",\"Address\":" +
                    "\"Avda. de la Constitución 2222\",\"City\":\"México D.F.\",\"Region\":null,\"PostalCode\":" +
                    "\"05021\",\"Country\":\"Mexico\",\"Phone\":\"(5) 555-4729\",\"Fax\":\"(5) 555-3745\"},{\"Custom" +
                    "erID\":\"ANTON\",\"CompanyName\":\"Antonio Moreno Taquería\",\"ContactName\":\"Antonio Mor" +
                    "eno\",\"ContactTitle\":\"Owner\",\"Address\":\"Mataderos  2312\",\"City\":\"México D.F.\",\"Re" +
                    "gion\":null,\"PostalCode\":\"05023\",\"Country\":\"Mexico\",\"Phone\":\"(5) 555-3932\",\"Fax\":" +
                    "null},{\"CustomerID\":\"AROUT\",\"CompanyName\":\"Around the Horn\",\"ContactName\":\"Thoma" +
                    "s Hardy\",\"ContactTitle\":\"Sales Representative\",\"Address\":\"120 Hanover Sq.\",\"City" +
                    "\":\"London\",\"Region\":null,\"PostalCode\":\"WA1 1DP\",\"Country\":\"UK\",\"Phone\":\"(171) 55" +
                    "5-7788\",\"Fax\":\"(171) 555-6750\"},{\"CustomerID\":\"BERGS\",\"CompanyName\":\"Berglunds s" +
                    "nabbköp\",\"ContactName\":\"Christina Berglund\",\"ContactTitle\":\"Order Administrator\"" +
                    ",\"Address\":\"Berguvsvägen  8\",\"City\":\"Luleå\",\"Region\":null,\"PostalCode\":\"S-958 22" +
                    "\",\"Country\":\"Sweden\",\"Phone\":\"0921-12 34 65\",\"Fax\":\"0921-12 34 67\"},{\"CustomerID" +
                    "\":\"BLAUS\",\"CompanyName\":\"Blauer See Delikatessen\",\"ContactName\":\"Hanna Moos\",\"Co" +
                    "ntactTitle\":\"Sales Representative\",\"Address\":\"Forsterstr. 57\",\"City\":\"Mannheim\"," +
                    "\"Region\":null,\"PostalCode\":\"68306\",\"Country\":\"Germany\",\"Phone\":\"0621-08460\",\"Fax" +
                    "\":\"0621-08924\"},{\"CustomerID\":\"BLONP\",\"CompanyName\":\"Blondesddsl père et fils\",\"" +
                    "ContactName\":\"Frédérique Citeaux\",\"ContactTitle\":\"Marketing Manager\",\"Address\":\"" +
                    "24, place Kléber\",\"City\":\"Strasbourg\",\"Region\":null,\"PostalCode\":\"67000\",\"Countr" +
                    "y\":\"France\",\"Phone\":\"88.60.15.31\",\"Fax\":\"88.60.15.32\"},{\"CustomerID\":\"BOLID\",\"Co" +
                    "mpanyName\":\"Bólido Comidas preparadas\",\"ContactName\":\"Martín Sommer\",\"ContactTit" +
                    "le\":\"Owner\",\"Address\":\"C/ Araquil, 67\",\"City\":\"Madrid\",\"Region\":null,\"PostalCode" +
                    "\":\"28023\",\"Country\":\"Spain\",\"Phone\":\"(91) 555 22 82\",\"Fax\":\"(91) 555 91 99\"},{\"C" +
                    "ustomerID\":\"BONAP\",\"CompanyName\":\"Bon app\'\",\"ContactName\":\"Laurence Lebihan\",\"Co" +
                    "ntactTitle\":\"Owner\",\"Address\":\"12, rue des Bouchers\",\"City\":\"Marseille\",\"Region\"" +
                    ":null,\"PostalCode\":\"13008\",\"Country\":\"France\",\"Phone\":\"91.24.45.40\",\"Fax\":\"91.24" +
                    ".45.41\"},{\"CustomerID\":\"BOTTM\",\"CompanyName\":\"Bottom-Dollar Markets\",\"ContactNam" +
                    "e\":\"Elizabeth Lincoln\",\"ContactTitle\":\"Accounting Manager\",\"Address\":\"23 Tsawass" +
                    "en Blvd.\",\"City\":\"Tsawassen\",\"Region\":\"BC\",\"PostalCode\":\"T2F 8M4\",\"Country\":\"Can" +
                    "ada\",\"Phone\":\"(604) 555-4729\",\"Fax\":\"(604) 555-3745\"},{\"CustomerID\":\"BSBEV\",\"Com" +
                    "panyName\":\"B\'s Beverages\",\"ContactName\":\"Victoria Ashworth\",\"ContactTitle\":\"Sale" +
                    "s Representative\",\"Address\":\"Fauntleroy Circus\",\"City\":\"London\",\"Region\":null,\"P" +
                    "ostalCode\":\"EC2 5NT\",\"Country\":\"UK\",\"Phone\":\"(171) 555-1212\",\"Fax\":null},{\"Custo" +
                    "merID\":\"CACTU\",\"CompanyName\":\"Cactus Comidas para llevar\",\"ContactName\":\"Patrici" +
                    "o Simpson\",\"ContactTitle\":\"Sales Agent\",\"Address\":\"Cerrito 333\",\"City\":\"Buenos A" +
                    "ires\",\"Region\":null,\"PostalCode\":\"1010\",\"Country\":\"Argentina\",\"Phone\":\"(1) 135-5" +
                    "555\",\"Fax\":\"(1) 135-4892\"},{\"CustomerID\":\"CENTC\",\"CompanyName\":\"Centro comercial" +
                    " Moctezuma\",\"ContactName\":\"Francisco Chang\",\"ContactTitle\":\"Marketing Manager\",\"" +
                    "Address\":\"Sierras de Granada 9993\",\"City\":\"México D.F.\",\"Region\":null,\"PostalCod" +
                    "e\":\"05022\",\"Country\":\"Mexico\",\"Phone\":\"(5) 555-3392\",\"Fax\":\"(5) 555-7293\"},{\"Cus" +
                    "tomerID\":\"CHOPS\",\"CompanyName\":\"Chop-suey Chinese\",\"ContactName\":\"Yang Wang\",\"Co" +
                    "ntactTitle\":\"Owner\",\"Address\":\"Hauptstr. 29\",\"City\":\"Bern\",\"Region\":null,\"Postal" +
                    "Code\":\"3012\",\"Country\":\"Switzerland\",\"Phone\":\"0452-076545\",\"Fax\":null},{\"Custome" +
                    "rID\":\"COMMI\",\"CompanyName\":\"Comércio Mineiro\",\"ContactName\":\"Pedro Afonso\",\"Cont" +
                    "actTitle\":\"Sales Associate\",\"Address\":\"Av. dos Lusíadas, 23\",\"City\":\"Sao Paulo\"," +
                    "\"Region\":\"SP\",\"PostalCode\":\"05432-043\",\"Country\":\"Brazil\",\"Phone\":\"(11) 555-7647" +
                    "\",\"Fax\":null},{\"CustomerID\":\"CONSH\",\"CompanyName\":\"Consolidated Holdings\",\"Conta" +
                    "ctName\":\"Elizabeth Brown\",\"ContactTitle\":\"Sales Representative\",\"Address\":\"Berke" +
                    "ley Gardens 12  Brewery\",\"City\":\"London\",\"Region\":null,\"PostalCode\":\"WX1 6LT\",\"C" +
                    "ountry\":\"UK\",\"Phone\":\"(171) 555-2282\",\"Fax\":\"(171) 555-9199\"},{\"CustomerID\":\"DRA" +
                    "CD\",\"CompanyName\":\"Drachenblut Delikatessen\",\"ContactName\":\"Sven Ottlieb\",\"Conta" +
                    "ctTitle\":\"Order Administrator\",\"Address\":\"Walserweg 21\",\"City\":\"Aachen\",\"Region\"" +
                    ":null,\"PostalCode\":\"52066\",\"Country\":\"Germany\",\"Phone\":\"0241-039123\",\"Fax\":\"0241" +
                    "-059428\"},{\"CustomerID\":\"DUMON\",\"CompanyName\":\"Du monde entier\",\"ContactName\":\"J" +
                    "anine Labrune\",\"ContactTitle\":\"Owner\",\"Address\":\"67, rue des Cinquante Otages\",\"" +
                    "City\":\"Nantes\",\"Region\":null,\"PostalCode\":\"44000\",\"Country\":\"France\",\"Phone\":\"40" +
                    ".67.88.88\",\"Fax\":\"40.67.89.89\"},{\"CustomerID\":\"EASTC\",\"CompanyName\":\"Eastern Con" +
                    "nection\",\"ContactName\":\"Ann Devon\",\"ContactTitle\":\"Sales Agent\",\"Address\":\"35 Ki" +
                    "ng George\",\"City\":\"London\",\"Region\":null,\"PostalCode\":\"WX3 6FW\",\"Country\":\"UK\",\"" +
                    "Phone\":\"(171) 555-0297\",\"Fax\":\"(171) 555-3373\"},{\"CustomerID\":\"ERNSH\",\"CompanyNa" +
                    "me\":\"Ernst Handel\",\"ContactName\":\"Roland Mendel\",\"ContactTitle\":\"Sales Manager\"," +
                    "\"Address\":\"Kirchgasse 6\",\"City\":\"Graz\",\"Region\":null,\"PostalCode\":\"8010\",\"Countr" +
                    "y\":\"Austria\",\"Phone\":\"7675-3425\",\"Fax\":\"7675-3426\"},{\"CustomerID\":\"FAMIA\",\"Compa" +
                    "nyName\":\"Familia Arquibaldo\",\"ContactName\":\"Aria Cruz\",\"ContactTitle\":\"Marketing" +
                    " Assistant\",\"Address\":\"Rua Orós, 92\",\"City\":\"Sao Paulo\",\"Region\":\"SP\",\"PostalCod" +
                    "e\":\"05442-030\",\"Country\":\"Brazil\",\"Phone\":\"(11) 555-9857\",\"Fax\":null},{\"Customer" +
                    "ID\":\"FISSA\",\"CompanyName\":\"FISSA Fabrica Inter. Salchichas S.A.\",\"ContactName\":\"" +
                    "Diego Roel\",\"ContactTitle\":\"Accounting Manager\",\"Address\":\"C/ Moralzarzal, 86\",\"" +
                    "City\":\"Madrid\",\"Region\":null,\"PostalCode\":\"28034\",\"Country\":\"Spain\",\"Phone\":\"(91" +
                    ") 555 94 44\",\"Fax\":\"(91) 555 55 93\"},{\"CustomerID\":\"FOLIG\",\"CompanyName\":\"Folies" +
                    " gourmandes\",\"ContactName\":\"Martine Rancé\",\"ContactTitle\":\"Assistant Sales Agent" +
                    "\",\"Address\":\"184, chaussée de Tournai\",\"City\":\"Lille\",\"Region\":null,\"PostalCode\"" +
                    ":\"59000\",\"Country\":\"France\",\"Phone\":\"20.16.10.16\",\"Fax\":\"20.16.10.17\"},{\"Custome" +
                    "rID\":\"FOLKO\",\"CompanyName\":\"Folk och fä HB\",\"ContactName\":\"Maria Larsson\",\"Conta" +
                    "ctTitle\":\"Owner\",\"Address\":\"Åkergatan 24\",\"City\":\"Bräcke\",\"Region\":null,\"PostalC" +
                    "ode\":\"S-844 67\",\"Country\":\"Sweden\",\"Phone\":\"0695-34 67 21\",\"Fax\":null},{\"Custome" +
                    "rID\":\"FRANK\",\"CompanyName\":\"Frankenversand\",\"ContactName\":\"Peter Franken\",\"Conta" +
                    "ctTitle\":\"Marketing Manager\",\"Address\":\"Berliner Platz 43\",\"City\":\"München\",\"Reg" +
                    "ion\":null,\"PostalCode\":\"80805\",\"Country\":\"Germany\",\"Phone\":\"089-0877310\",\"Fax\":\"" +
                    "089-0877451\"},{\"CustomerID\":\"FRANR\",\"CompanyName\":\"France restauration\",\"Contact" +
                    "Name\":\"Carine Schmitt\",\"ContactTitle\":\"Marketing Manager\",\"Address\":\"54, rue Roy" +
                    "ale\",\"City\":\"Nantes\",\"Region\":null,\"PostalCode\":\"44000\",\"Country\":\"France\",\"Phon" +
                    "e\":\"40.32.21.21\",\"Fax\":\"40.32.21.20\"},{\"CustomerID\":\"FRANS\",\"CompanyName\":\"Franc" +
                    "hi S.p.A.\",\"ContactName\":\"Paolo Accorti\",\"ContactTitle\":\"Sales Representative\",\"" +
                    "Address\":\"Via Monte Bianco 34\",\"City\":\"Torino\",\"Region\":null,\"PostalCode\":\"10100" +
                    "\",\"Country\":\"Italy\",\"Phone\":\"011-4988260\",\"Fax\":\"011-4988261\"},{\"CustomerID\":\"FU" +
                    "RIB\",\"CompanyName\":\"Furia Bacalhau e Frutos do Mar\",\"ContactName\":\"Lino Rodrigue" +
                    "z\",\"ContactTitle\":\"Sales Manager\",\"Address\":\"Jardim das rosas n. 32\",\"City\":\"Lis" +
                    "boa\",\"Region\":null,\"PostalCode\":\"1675\",\"Country\":\"Portugal\",\"Phone\":\"(1) 354-253" +
                    "4\",\"Fax\":\"(1) 354-2535\"},{\"CustomerID\":\"GALED\",\"CompanyName\":\"Galería del gastró" +
                    "nomo\",\"ContactName\":\"Eduardo Saavedra\",\"ContactTitle\":\"Marketing Manager\",\"Addre" +
                    "ss\":\"Rambla de Cataluña, 23\",\"City\":\"Barcelona\",\"Region\":null,\"PostalCode\":\"0802" +
                    "2\",\"Country\":\"Spain\",\"Phone\":\"(93) 203 4560\",\"Fax\":\"(93) 203 4561\"},{\"CustomerID" +
                    "\":\"GODOS\",\"CompanyName\":\"Godos Cocina Típica\",\"ContactName\":\"José Pedro Freyre\"," +
                    "\"ContactTitle\":\"Sales Manager\",\"Address\":\"C/ Romero, 33\",\"City\":\"Sevilla\",\"Regio" +
                    "n\":null,\"PostalCode\":\"41101\",\"Country\":\"Spain\",\"Phone\":\"(95) 555 82 82\",\"Fax\":nu" +
                    "ll},{\"CustomerID\":\"GOURL\",\"CompanyName\":\"Gourmet Lanchonetes\",\"ContactName\":\"And" +
                    "ré Fonseca\",\"ContactTitle\":\"Sales Associate\",\"Address\":\"Av. Brasil, 442\",\"City\":" +
                    "\"Campinas\",\"Region\":\"SP\",\"PostalCode\":\"04876-786\",\"Country\":\"Brazil\",\"Phone\":\"(1" +
                    "1) 555-9482\",\"Fax\":null},{\"CustomerID\":\"GREAL\",\"CompanyName\":\"Great Lakes Food M" +
                    "arket\",\"ContactName\":\"Howard Snyder\",\"ContactTitle\":\"Marketing Manager\",\"Address" +
                    "\":\"2732 Baker Blvd.\",\"City\":\"Eugene\",\"Region\":\"OR\",\"PostalCode\":\"97403\",\"Country" +
                    "\":\"USA\",\"Phone\":\"(503) 555-7555\",\"Fax\":null},{\"CustomerID\":\"GROSR\",\"CompanyName\"" +
                    ":\"GROSELLA-Restaurante\",\"ContactName\":\"Manuel Pereira\",\"ContactTitle\":\"Owner\",\"A" +
                    "ddress\":\"5ª Ave. Los Palos Grandes\",\"City\":\"Caracas\",\"Region\":\"DF\",\"PostalCode\":" +
                    "\"1081\",\"Country\":\"Venezuela\",\"Phone\":\"(2) 283-2951\",\"Fax\":\"(2) 283-3397\"},{\"Cust" +
                    "omerID\":\"HANAR\",\"CompanyName\":\"Hanari Carnes\",\"ContactName\":\"Mario Pontes\",\"Cont" +
                    "actTitle\":\"Accounting Manager\",\"Address\":\"Rua do Paço, 67\",\"City\":\"Rio de Janeir" +
                    "o\",\"Region\":\"RJ\",\"PostalCode\":\"05454-876\",\"Country\":\"Brazil\",\"Phone\":\"(21) 555-0" +
                    "091\",\"Fax\":\"(21) 555-8765\"},{\"CustomerID\":\"HILAA\",\"CompanyName\":\"HILARION-Abasto" +
                    "s\",\"ContactName\":\"Carlos Hernández\",\"ContactTitle\":\"Sales Representative\",\"Addre" +
                    "ss\":\"Carrera 22 con Ave. Carlos Soublette #8-35\",\"City\":\"San Cristóbal\",\"Region\"" +
                    ":\"Táchira\",\"PostalCode\":\"5022\",\"Country\":\"Venezuela\",\"Phone\":\"(5) 555-1340\",\"Fax" +
                    "\":\"(5) 555-1948\"},{\"CustomerID\":\"HUNGC\",\"CompanyName\":\"Hungry Coyote Import Stor" +
                    "e\",\"ContactName\":\"Yoshi Latimer\",\"ContactTitle\":\"Sales Representative\",\"Address\"" +
                    ":\"City Center Plaza 516 Main St.\",\"City\":\"Elgin\",\"Region\":\"OR\",\"PostalCode\":\"978" +
                    "27\",\"Country\":\"USA\",\"Phone\":\"(503) 555-6874\",\"Fax\":\"(503) 555-2376\"},{\"CustomerI" +
                    "D\":\"HUNGO\",\"CompanyName\":\"Hungry Owl All-Night Grocers\",\"ContactName\":\"Patricia " +
                    "McKenna\",\"ContactTitle\":\"Sales Associate\",\"Address\":\"8 Johnstown Road\",\"City\":\"C" +
                    "ork\",\"Region\":\"Co. Cork\",\"PostalCode\":null,\"Country\":\"Ireland\",\"Phone\":\"2967 542" +
                    "\",\"Fax\":\"2967 3333\"},{\"CustomerID\":\"ISLAT\",\"CompanyName\":\"Island Trading\",\"Conta" +
                    "ctName\":\"Helen Bennett\",\"ContactTitle\":\"Marketing Manager\",\"Address\":\"Garden Hou" +
                    "se Crowther Way\",\"City\":\"Cowes\",\"Region\":\"Isle of Wight\",\"PostalCode\":\"PO31 7PJ\"" +
                    ",\"Country\":\"UK\",\"Phone\":\"(198) 555-8888\",\"Fax\":null},{\"CustomerID\":\"KOENE\",\"Comp" +
                    "anyName\":\"Königlich Essen\",\"ContactName\":\"Philip Cramer\",\"ContactTitle\":\"Sales A" +
                    "ssociate\",\"Address\":\"Maubelstr. 90\",\"City\":\"Brandenburg\",\"Region\":null,\"PostalCo" +
                    "de\":\"14776\",\"Country\":\"Germany\",\"Phone\":\"0555-09876\",\"Fax\":null},{\"CustomerID\":\"" +
                    "LACOR\",\"CompanyName\":\"La corne d\'abondance\",\"ContactName\":\"Daniel Tonini\",\"Conta" +
                    "ctTitle\":\"Sales Representative\",\"Address\":\"67, avenue de l\'Europe\",\"City\":\"Versa" +
                    "illes\",\"Region\":null,\"PostalCode\":\"78000\",\"Country\":\"France\",\"Phone\":\"30.59.84.1" +
                    "0\",\"Fax\":\"30.59.85.11\"},{\"CustomerID\":\"LAMAI\",\"CompanyName\":\"La maison d\'Asie\",\"" +
                    "ContactName\":\"Annette Roulet\",\"ContactTitle\":\"Sales Manager\",\"Address\":\"1 rue Al" +
                    "sace-Lorraine\",\"City\":\"Toulouse\",\"Region\":null,\"PostalCode\":\"31000\",\"Country\":\"F" +
                    "rance\",\"Phone\":\"61.77.61.10\",\"Fax\":\"61.77.61.11\"},{\"CustomerID\":\"LAUGB\",\"Company" +
                    "Name\":\"Laughing Bacchus Wine Cellars\",\"ContactName\":\"Yoshi Tannamuri\",\"ContactTi" +
                    "tle\":\"Marketing Assistant\",\"Address\":\"1900 Oak St.\",\"City\":\"Vancouver\",\"Region\":" +
                    "\"BC\",\"PostalCode\":\"V3F 2K1\",\"Country\":\"Canada\",\"Phone\":\"(604) 555-3392\",\"Fax\":\"(" +
                    "604) 555-7293\"},{\"CustomerID\":\"LAZYK\",\"CompanyName\":\"Lazy K Kountry Store\",\"Cont" +
                    "actName\":\"John Steel\",\"ContactTitle\":\"Marketing Manager\",\"Address\":\"12 Orchestra" +
                    " Terrace\",\"City\":\"Walla Walla\",\"Region\":\"WA\",\"PostalCode\":\"99362\",\"Country\":\"USA" +
                    "\",\"Phone\":\"(509) 555-7969\",\"Fax\":\"(509) 555-6221\"},{\"CustomerID\":\"LEHMS\",\"Compan" +
                    "yName\":\"Lehmanns Marktstand\",\"ContactName\":\"Renate Messner\",\"ContactTitle\":\"Sale" +
                    "s Representative\",\"Address\":\"Magazinweg 7\",\"City\":\"Frankfurt a.M.\",\"Region\":null" +
                    ",\"PostalCode\":\"60528\",\"Country\":\"Germany\",\"Phone\":\"069-0245984\",\"Fax\":\"069-02458" +
                    "74\"},{\"CustomerID\":\"LETSS\",\"CompanyName\":\"Let\'s Stop N Shop\",\"ContactName\":\"Jaim" +
                    "e Yorres\",\"ContactTitle\":\"Owner\",\"Address\":\"87 Polk St. Suite 5\",\"City\":\"San Fra" +
                    "ncisco\",\"Region\":\"CA\",\"PostalCode\":\"94117\",\"Country\":\"USA\",\"Phone\":\"(415) 555-59" +
                    "38\",\"Fax\":null},{\"CustomerID\":\"LILAS\",\"CompanyName\":\"LILA-Supermercado\",\"Contact" +
                    "Name\":\"Carlos González\",\"ContactTitle\":\"Accounting Manager\",\"Address\":\"Carrera 5" +
                    "2 con Ave. Bolívar #65-98 Llano Largo\",\"City\":\"Barquisimeto\",\"Region\":\"Lara\",\"Po" +
                    "stalCode\":\"3508\",\"Country\":\"Venezuela\",\"Phone\":\"(9) 331-6954\",\"Fax\":\"(9) 331-725" +
                    "6\"},{\"CustomerID\":\"LINOD\",\"CompanyName\":\"LINO-Delicateses\",\"ContactName\":\"Felipe" +
                    " Izquierdo\",\"ContactTitle\":\"Owner\",\"Address\":\"Ave. 5 de Mayo Porlamar\",\"City\":\"I" +
                    ". de Margarita\",\"Region\":\"Nueva Esparta\",\"PostalCode\":\"4980\",\"Country\":\"Venezuel" +
                    "a\",\"Phone\":\"(8) 34-56-12\",\"Fax\":\"(8) 34-93-93\"},{\"CustomerID\":\"LONEP\",\"CompanyNa" +
                    "me\":\"Lonesome Pine Restaurant\",\"ContactName\":\"Fran Wilson\",\"ContactTitle\":\"Sales" +
                    " Manager\",\"Address\":\"89 Chiaroscuro Rd.\",\"City\":\"Portland\",\"Region\":\"OR\",\"Postal" +
                    "Code\":\"97219\",\"Country\":\"USA\",\"Phone\":\"(503) 555-9573\",\"Fax\":\"(503) 555-9646\"},{" +
                    "\"CustomerID\":\"MAGAA\",\"CompanyName\":\"Magazzini Alimentari Riuniti\",\"ContactName\":" +
                    "\"Giovanni Rovelli\",\"ContactTitle\":\"Marketing Manager\",\"Address\":\"Via Ludovico il" +
                    " Moro 22\",\"City\":\"Bergamo\",\"Region\":null,\"PostalCode\":\"24100\",\"Country\":\"Italy\"," +
                    "\"Phone\":\"035-640230\",\"Fax\":\"035-640231\"},{\"CustomerID\":\"MAISD\",\"CompanyName\":\"Ma" +
                    "ison Dewey\",\"ContactName\":\"Catherine Dewey\",\"ContactTitle\":\"Sales Agent\",\"Addres" +
                    "s\":\"Rue Joseph-Bens 532\",\"City\":\"Bruxelles\",\"Region\":null,\"PostalCode\":\"B-1180\"," +
                    "\"Country\":\"Belgium\",\"Phone\":\"(02) 201 24 67\",\"Fax\":\"(02) 201 24 68\"},{\"CustomerI" +
                    "D\":\"MEREP\",\"CompanyName\":\"Mère Paillarde\",\"ContactName\":\"Jean Fresnière\",\"Contac" +
                    "tTitle\":\"Marketing Assistant\",\"Address\":\"43 rue St. Laurent\",\"City\":\"Montréal\",\"" +
                    "Region\":\"Québec\",\"PostalCode\":\"H1J 1C3\",\"Country\":\"Canada\",\"Phone\":\"(514) 555-80" +
                    "54\",\"Fax\":\"(514) 555-8055\"},{\"CustomerID\":\"MORGK\",\"CompanyName\":\"Morgenstern Ges" +
                    "undkost\",\"ContactName\":\"Alexander Feuer\",\"ContactTitle\":\"Marketing Assistant\",\"A" +
                    "ddress\":\"Heerstr. 22\",\"City\":\"Leipzig\",\"Region\":null,\"PostalCode\":\"04179\",\"Count" +
                    "ry\":\"Germany\",\"Phone\":\"0342-023176\",\"Fax\":null},{\"CustomerID\":\"NORTS\",\"CompanyNa" +
                    "me\":\"North/South\",\"ContactName\":\"Simon Crowther\",\"ContactTitle\":\"Sales Associate" +
                    "\",\"Address\":\"South House 300 Queensbridge\",\"City\":\"London\",\"Region\":null,\"Postal" +
                    "Code\":\"SW7 1RZ\",\"Country\":\"UK\",\"Phone\":\"(171) 555-7733\",\"Fax\":\"(171) 555-2530\"}," +
                    "{\"CustomerID\":\"OCEAN\",\"CompanyName\":\"Océano Atlántico Ltda.\",\"ContactName\":\"Yvon" +
                    "ne Moncada\",\"ContactTitle\":\"Sales Agent\",\"Address\":\"Ing. Gustavo Moncada 8585 Pi" +
                    "so 20-A\",\"City\":\"Buenos Aires\",\"Region\":null,\"PostalCode\":\"1010\",\"Country\":\"Arge" +
                    "ntina\",\"Phone\":\"(1) 135-5333\",\"Fax\":\"(1) 135-5535\"},{\"CustomerID\":\"OLDWO\",\"Compa" +
                    "nyName\":\"Old World Delicatessen\",\"ContactName\":\"Rene Phillips\",\"ContactTitle\":\"S" +
                    "ales Representative\",\"Address\":\"2743 Bering St.\",\"City\":\"Anchorage\",\"Region\":\"AK" +
                    "\",\"PostalCode\":\"99508\",\"Country\":\"USA\",\"Phone\":\"(907) 555-7584\",\"Fax\":\"(907) 555" +
                    "-2880\"},{\"CustomerID\":\"OTTIK\",\"CompanyName\":\"Ottilies Käseladen\",\"ContactName\":\"" +
                    "Henriette Pfalzheim\",\"ContactTitle\":\"Owner\",\"Address\":\"Mehrheimerstr. 369\",\"City" +
                    "\":\"Köln\",\"Region\":null,\"PostalCode\":\"50739\",\"Country\":\"Germany\",\"Phone\":\"0221-06" +
                    "44327\",\"Fax\":\"0221-0765721\"},{\"CustomerID\":\"PARIS\",\"CompanyName\":\"Paris spéciali" +
                    "tés\",\"ContactName\":\"Marie Bertrand\",\"ContactTitle\":\"Owner\",\"Address\":\"265, boule" +
                    "vard Charonne\",\"City\":\"Paris\",\"Region\":null,\"PostalCode\":\"75012\",\"Country\":\"Fran" +
                    "ce\",\"Phone\":\"(1) 42.34.22.66\",\"Fax\":\"(1) 42.34.22.77\"},{\"CustomerID\":\"PERIC\",\"Co" +
                    "mpanyName\":\"Pericles Comidas clásicas\",\"ContactName\":\"Guillermo Fernández\",\"Cont" +
                    "actTitle\":\"Sales Representative\",\"Address\":\"Calle Dr. Jorge Cash 321\",\"City\":\"Mé" +
                    "xico D.F.\",\"Region\":null,\"PostalCode\":\"05033\",\"Country\":\"Mexico\",\"Phone\":\"(5) 55" +
                    "2-3745\",\"Fax\":\"(5) 545-3745\"},{\"CustomerID\":\"PICCO\",\"CompanyName\":\"Piccolo und m" +
                    "ehr\",\"ContactName\":\"Georg Pipps\",\"ContactTitle\":\"Sales Manager\",\"Address\":\"Geisl" +
                    "weg 14\",\"City\":\"Salzburg\",\"Region\":null,\"PostalCode\":\"5020\",\"Country\":\"Austria\"," +
                    "\"Phone\":\"6562-9722\",\"Fax\":\"6562-9723\"},{\"CustomerID\":\"PRINI\",\"CompanyName\":\"Prin" +
                    "cesa Isabel Vinhos\",\"ContactName\":\"Isabel de Castro\",\"ContactTitle\":\"Sales Repre" +
                    "sentative\",\"Address\":\"Estrada da saúde n. 58\",\"City\":\"Lisboa\",\"Region\":null,\"Pos" +
                    "talCode\":\"1756\",\"Country\":\"Portugal\",\"Phone\":\"(1) 356-5634\",\"Fax\":null},{\"Custom" +
                    "erID\":\"QUEDE\",\"CompanyName\":\"Que Delícia\",\"ContactName\":\"Bernardo Batista\",\"Cont" +
                    "actTitle\":\"Accounting Manager\",\"Address\":\"Rua da Panificadora, 12\",\"City\":\"Rio d" +
                    "e Janeiro\",\"Region\":\"RJ\",\"PostalCode\":\"02389-673\",\"Country\":\"Brazil\",\"Phone\":\"(2" +
                    "1) 555-4252\",\"Fax\":\"(21) 555-4545\"},{\"CustomerID\":\"QUEEN\",\"CompanyName\":\"Queen C" +
                    "ozinha\",\"ContactName\":\"Lúcia Carvalho\",\"ContactTitle\":\"Marketing Assistant\",\"Add" +
                    "ress\":\"Alameda dos Canàrios, 891\",\"City\":\"Sao Paulo\",\"Region\":\"SP\",\"PostalCode\":" +
                    "\"05487-020\",\"Country\":\"Brazil\",\"Phone\":\"(11) 555-1189\",\"Fax\":null},{\"CustomerID\"" +
                    ":\"QUICK\",\"CompanyName\":\"QUICK-Stop\",\"ContactName\":\"Horst Kloss\",\"ContactTitle\":\"" +
                    "Accounting Manager\",\"Address\":\"Taucherstraße 10\",\"City\":\"Cunewalde\",\"Region\":nul" +
                    "l,\"PostalCode\":\"01307\",\"Country\":\"Germany\",\"Phone\":\"0372-035188\",\"Fax\":null},{\"C" +
                    "ustomerID\":\"RANCH\",\"CompanyName\":\"Rancho grande\",\"ContactName\":\"Sergio Gutiérrez" +
                    "\",\"ContactTitle\":\"Sales Representative\",\"Address\":\"Av. del Libertador 900\",\"City" +
                    "\":\"Buenos Aires\",\"Region\":null,\"PostalCode\":\"1010\",\"Country\":\"Argentina\",\"Phone\"" +
                    ":\"(1) 123-5555\",\"Fax\":\"(1) 123-5556\"},{\"CustomerID\":\"RATTC\",\"CompanyName\":\"Rattl" +
                    "esnake Canyon Grocery\",\"ContactName\":\"Paula Wilson\",\"ContactTitle\":\"Assistant Sa" +
                    "les Representative\",\"Address\":\"2817 Milton Dr.\",\"City\":\"Albuquerque\",\"Region\":\"N" +
                    "M\",\"PostalCode\":\"87110\",\"Country\":\"USA\",\"Phone\":\"(505) 555-5939\",\"Fax\":\"(505) 55" +
                    "5-3620\"},{\"CustomerID\":\"REGGC\",\"CompanyName\":\"Reggiani Caseifici\",\"ContactName\":" +
                    "\"Maurizio Moroni\",\"ContactTitle\":\"Sales Associate\",\"Address\":\"Strada Provinciale" +
                    " 124\",\"City\":\"Reggio Emilia\",\"Region\":null,\"PostalCode\":\"42100\",\"Country\":\"Italy" +
                    "\",\"Phone\":\"0522-556721\",\"Fax\":\"0522-556722\"},{\"CustomerID\":\"RICAR\",\"CompanyName\"" +
                    ":\"Ricardo Adocicados\",\"ContactName\":\"Janete Limeira\",\"ContactTitle\":\"Assistant S" +
                    "ales Agent\",\"Address\":\"Av. Copacabana, 267\",\"City\":\"Rio de Janeiro\",\"Region\":\"RJ" +
                    "\",\"PostalCode\":\"02389-890\",\"Country\":\"Brazil\",\"Phone\":\"(21) 555-3412\",\"Fax\":null" +
                    "},{\"CustomerID\":\"RICSU\",\"CompanyName\":\"Richter Supermarkt\",\"ContactName\":\"Michae" +
                    "l Holz\",\"ContactTitle\":\"Sales Manager\",\"Address\":\"Grenzacherweg 237\",\"City\":\"Gen" +
                    "ève\",\"Region\":null,\"PostalCode\":\"1203\",\"Country\":\"Switzerland\",\"Phone\":\"0897-034" +
                    "214\",\"Fax\":null},{\"CustomerID\":\"ROMEY\",\"CompanyName\":\"Romero y tomillo\",\"Contact" +
                    "Name\":\"Alejandra Camino\",\"ContactTitle\":\"Accounting Manager\",\"Address\":\"Gran Vía" +
                    ", 1\",\"City\":\"Madrid\",\"Region\":null,\"PostalCode\":\"28001\",\"Country\":\"Spain\",\"Phone" +
                    "\":\"(91) 745 6200\",\"Fax\":\"(91) 745 6210\"},{\"CustomerID\":\"SANTG\",\"CompanyName\":\"Sa" +
                    "nté Gourmet\",\"ContactName\":\"Jonas Bergulfsen\",\"ContactTitle\":\"Owner\",\"Address\":\"" +
                    "Erling Skakkes gate 78\",\"City\":\"Stavern\",\"Region\":null,\"PostalCode\":\"4110\",\"Coun" +
                    "try\":\"Norway\",\"Phone\":\"07-98 92 35\",\"Fax\":\"07-98 92 47\"},{\"CustomerID\":\"SAVEA\",\"" +
                    "CompanyName\":\"Save-a-lot Markets\",\"ContactName\":\"Jose Pavarotti\",\"ContactTitle\":" +
                    "\"Sales Representative\",\"Address\":\"187 Suffolk Ln.\",\"City\":\"Boise\",\"Region\":\"ID\"," +
                    "\"PostalCode\":\"83720\",\"Country\":\"USA\",\"Phone\":\"(208) 555-8097\",\"Fax\":null},{\"Cust" +
                    "omerID\":\"SEVES\",\"CompanyName\":\"Seven Seas Imports\",\"ContactName\":\"Hari Kumar\",\"C" +
                    "ontactTitle\":\"Sales Manager\",\"Address\":\"90 Wadhurst Rd.\",\"City\":\"London\",\"Region" +
                    "\":null,\"PostalCode\":\"OX15 4NB\",\"Country\":\"UK\",\"Phone\":\"(171) 555-1717\",\"Fax\":\"(1" +
                    "71) 555-5646\"},{\"CustomerID\":\"SIMOB\",\"CompanyName\":\"Simons bistro\",\"ContactName\"" +
                    ":\"Jytte Petersen\",\"ContactTitle\":\"Owner\",\"Address\":\"Vinbæltet 34\",\"City\":\"Kobenh" +
                    "avn\",\"Region\":null,\"PostalCode\":\"1734\",\"Country\":\"Denmark\",\"Phone\":\"31 12 34 56\"" +
                    ",\"Fax\":\"31 13 35 57\"},{\"CustomerID\":\"SPECD\",\"CompanyName\":\"Spécialités du monde\"" +
                    ",\"ContactName\":\"Dominique Perrier\",\"ContactTitle\":\"Marketing Manager\",\"Address\":" +
                    "\"25, rue Lauriston\",\"City\":\"Paris\",\"Region\":null,\"PostalCode\":\"75016\",\"Country\":" +
                    "\"France\",\"Phone\":\"(1) 47.55.60.10\",\"Fax\":\"(1) 47.55.60.20\"},{\"CustomerID\":\"SPLIR" +
                    "\",\"CompanyName\":\"Split Rail Beer & Ale\",\"ContactName\":\"Art Braunschweiger\",\"Cont" +
                    "actTitle\":\"Sales Manager\",\"Address\":\"P.O. Box 555\",\"City\":\"Lander\",\"Region\":\"WY\"" +
                    ",\"PostalCode\":\"82520\",\"Country\":\"USA\",\"Phone\":\"(307) 555-4680\",\"Fax\":\"(307) 555-" +
                    "6525\"},{\"CustomerID\":\"SUPRD\",\"CompanyName\":\"Suprêmes délices\",\"ContactName\":\"Pas" +
                    "cale Cartrain\",\"ContactTitle\":\"Accounting Manager\",\"Address\":\"Boulevard Tirou, 2" +
                    "55\",\"City\":\"Charleroi\",\"Region\":null,\"PostalCode\":\"B-6000\",\"Country\":\"Belgium\",\"" +
                    "Phone\":\"(071) 23 67 22 20\",\"Fax\":\"(071) 23 67 22 21\"},{\"CustomerID\":\"THEBI\",\"Com" +
                    "panyName\":\"The Big Cheese\",\"ContactName\":\"Liz Nixon\",\"ContactTitle\":\"Marketing M" +
                    "anager\",\"Address\":\"89 Jefferson Way Suite 2\",\"City\":\"Portland\",\"Region\":\"OR\",\"Po" +
                    "stalCode\":\"97201\",\"Country\":\"USA\",\"Phone\":\"(503) 555-3612\",\"Fax\":null},{\"Custome" +
                    "rID\":\"THECR\",\"CompanyName\":\"The Cracker Box\",\"ContactName\":\"Liu Wong\",\"ContactTi" +
                    "tle\":\"Marketing Assistant\",\"Address\":\"55 Grizzly Peak Rd.\",\"City\":\"Butte\",\"Regio" +
                    "n\":\"MT\",\"PostalCode\":\"59801\",\"Country\":\"USA\",\"Phone\":\"(406) 555-5834\",\"Fax\":\"(40" +
                    "6) 555-8083\"},{\"CustomerID\":\"TOMSP\",\"CompanyName\":\"Toms Spezialitäten\",\"ContactN" +
                    "ame\":\"Karin Josephs\",\"ContactTitle\":\"Marketing Manager\",\"Address\":\"Luisenstr. 48" +
                    "\",\"City\":\"Münster\",\"Region\":null,\"PostalCode\":\"44087\",\"Country\":\"Germany\",\"Phone" +
                    "\":\"0251-031259\",\"Fax\":\"0251-035695\"},{\"CustomerID\":\"TORTU\",\"CompanyName\":\"Tortug" +
                    "a Restaurante\",\"ContactName\":\"Miguel Angel Paolino\",\"ContactTitle\":\"Owner\",\"Addr" +
                    "ess\":\"Avda. Azteca 123\",\"City\":\"México D.F.\",\"Region\":null,\"PostalCode\":\"05033\"," +
                    "\"Country\":\"Mexico\",\"Phone\":\"(5) 555-2933\",\"Fax\":null},{\"CustomerID\":\"TRADH\",\"Com" +
                    "panyName\":\"Tradição Hipermercados\",\"ContactName\":\"Anabela Domingues\",\"ContactTit" +
                    "le\":\"Sales Representative\",\"Address\":\"Av. Inês de Castro, 414\",\"City\":\"Sao Paulo" +
                    "\",\"Region\":\"SP\",\"PostalCode\":\"05634-030\",\"Country\":\"Brazil\",\"Phone\":\"(11) 555-21" +
                    "67\",\"Fax\":\"(11) 555-2168\"},{\"CustomerID\":\"TRAIH\",\"CompanyName\":\"Trail\'s Head Gou" +
                    "rmet Provisioners\",\"ContactName\":\"Helvetius Nagy\",\"ContactTitle\":\"Sales Associat" +
                    "e\",\"Address\":\"722 DaVinci Blvd.\",\"City\":\"Kirkland\",\"Region\":\"WA\",\"PostalCode\":\"9" +
                    "8034\",\"Country\":\"USA\",\"Phone\":\"(206) 555-8257\",\"Fax\":\"(206) 555-2174\"},{\"Custome" +
                    "rID\":\"VAFFE\",\"CompanyName\":\"Vaffeljernet\",\"ContactName\":\"Palle Ibsen\",\"ContactTi" +
                    "tle\":\"Sales Manager\",\"Address\":\"Smagsloget 45\",\"City\":\"Århus\",\"Region\":null,\"Pos" +
                    "talCode\":\"8200\",\"Country\":\"Denmark\",\"Phone\":\"86 21 32 43\",\"Fax\":\"86 22 33 44\"},{" +
                    "\"CustomerID\":\"VICTE\",\"CompanyName\":\"Victuailles en stock\",\"ContactName\":\"Mary Sa" +
                    "veley\",\"ContactTitle\":\"Sales Agent\",\"Address\":\"2, rue du Commerce\",\"City\":\"Lyon\"" +
                    ",\"Region\":null,\"PostalCode\":\"69004\",\"Country\":\"France\",\"Phone\":\"78.32.54.86\",\"Fa" +
                    "x\":\"78.32.54.87\"},{\"CustomerID\":\"VINET\",\"CompanyName\":\"Vins et alcools Chevalier" +
                    "\",\"ContactName\":\"Paul Henriot\",\"ContactTitle\":\"Accounting Manager\",\"Address\":\"59" +
                    " rue de l\'Abbaye\",\"City\":\"Reims\",\"Region\":null,\"PostalCode\":\"51100\",\"Country\":\"F" +
                    "rance\",\"Phone\":\"26.47.15.10\",\"Fax\":\"26.47.15.11\"},{\"CustomerID\":\"WANDK\",\"Company" +
                    "Name\":\"Die Wandernde Kuh\",\"ContactName\":\"Rita Müller\",\"ContactTitle\":\"Sales Repr" +
                    "esentative\",\"Address\":\"Adenauerallee 900\",\"City\":\"Stuttgart\",\"Region\":null,\"Post" +
                    "alCode\":\"70563\",\"Country\":\"Germany\",\"Phone\":\"0711-020361\",\"Fax\":\"0711-035428\"},{" +
                    "\"CustomerID\":\"WARTH\",\"CompanyName\":\"Wartian Herkku\",\"ContactName\":\"Pirkko Koskit" +
                    "alo\",\"ContactTitle\":\"Accounting Manager\",\"Address\":\"Torikatu 38\",\"City\":\"Oulu\",\"" +
                    "Region\":null,\"PostalCode\":\"90110\",\"Country\":\"Finland\",\"Phone\":\"981-443655\",\"Fax\"" +
                    ":\"981-443655\"},{\"CustomerID\":\"WELLI\",\"CompanyName\":\"Wellington Importadora\",\"Con" +
                    "tactName\":\"Paula Parente\",\"ContactTitle\":\"Sales Manager\",\"Address\":\"Rua do Merca" +
                    "do, 12\",\"City\":\"Resende\",\"Region\":\"SP\",\"PostalCode\":\"08737-363\",\"Country\":\"Brazi" +
                    "l\",\"Phone\":\"(14) 555-8122\",\"Fax\":null},{\"CustomerID\":\"WHITC\",\"CompanyName\":\"Whit" +
                    "e Clover Markets\",\"ContactName\":\"Karl Jablonski\",\"ContactTitle\":\"Owner\",\"Address" +
                    "\":\"305 - 14th Ave. S. Suite 3B\",\"City\":\"Seattle\",\"Region\":\"WA\",\"PostalCode\":\"981" +
                    "28\",\"Country\":\"USA\",\"Phone\":\"(206) 555-4112\",\"Fax\":\"(206) 555-4115\"},{\"CustomerI" +
                    "D\":\"WILMK\",\"CompanyName\":\"Wilman Kala\",\"ContactName\":\"Matti Karttunen\",\"ContactT" +
                    "itle\":\"Owner/Marketing Assistant\",\"Address\":\"Keskuskatu 45\",\"City\":\"Helsinki\",\"R" +
                    "egion\":null,\"PostalCode\":\"21240\",\"Country\":\"Finland\",\"Phone\":\"90-224 8858\",\"Fax\"" +
                    ":\"90-224 8858\"},{\"CustomerID\":\"WOLZA\",\"CompanyName\":\"Wolski  Zajazd\",\"ContactNam" +
                    "e\":\"Zbyszek Piestrzeniewicz\",\"ContactTitle\":\"Owner\",\"Address\":\"ul. Filtrowa 68\"," +
                    "\"City\":\"Warszawa\",\"Region\":null,\"PostalCode\":\"01-012\",\"Country\":\"Poland\",\"Phone\"" +
                    ":\"(26) 642-7012\",\"Fax\":\"(26) 642-7012\"}]\r\n");
        }

    }


    
}