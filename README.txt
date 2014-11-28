Gør følgende for at få projektet til at køre:


1. Start med at oprette en tom database i SQL Server management studio. Databasen skal hedde "JohannesVidner"

2. Udpak filen "JohannesVidner.zip"

3. Åben mappen og start filen "JohannesVidnerProject". Derefter starter projektet op i visual studio

4. Der er 4 underprojekter i 1 solution, hvoraf det ene er et testprojekt. 
   Klik på pilen udfor "Model" projektet for at få vist indholdet.

5. Der findes 3 SQL scripts under model-projektet. Kør dem i følgende rækkefølge: 
		"ModelClasses.edmx.sql"
		"SQLQueryDatabaseUdtræk.sql" 
		"MereMockup.sql".

6. Nu er der testdata og projektet kan køres. 

(7). Hvis projektet fejler ved start er det muligt at der skal rettes i "connectionstrings". Der skal muligvis ændres "source=localhost" til "source=localhost\SQLEXPRESS".


     Connectionstrings findes i følgende to filer:
     - JohannesVidnerProject --> Web.config
     - Model --> App.Config