G�r f�lgende for at f� projektet til at k�re:


1. Start med at oprette en tom database i SQL Server management studio. Databasen skal hedde "JohannesVidner"

2. Udpak filen "JohannesVidner.zip"

3. �ben mappen og start filen "JohannesVidnerProject". Derefter starter projektet op i visual studio

4. Der er 4 underprojekter i 1 solution, hvoraf det ene er et testprojekt. 
   Klik p� pilen udfor "Model" projektet for at f� vist indholdet.

5. Der findes 3 SQL scripts under model-projektet. K�r dem i f�lgende r�kkef�lge: 
		"ModelClasses.edmx.sql"
		"SQLQueryDatabaseUdtr�k.sql" 
		"MereMockup.sql".

6. Nu er der testdata og projektet kan k�res. 

(7). Hvis projektet fejler ved start er det muligt at der skal rettes i "connectionstrings". Der skal muligvis �ndres "source=localhost" til "source=localhost\SQLEXPRESS".


     Connectionstrings findes i f�lgende to filer:
     - JohannesVidnerProject --> Web.config
     - Model --> App.Config