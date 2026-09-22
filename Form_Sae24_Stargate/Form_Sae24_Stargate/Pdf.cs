using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using Form_Sae24_Stargate;

public static class Pdf
{

    public static void GenererRapportMission(string planete, int numeroMission, DataTable tableBilan = null)
    {
        string nomFichier = "Rapport_Mission_" + planete + numeroMission + ".pdf";

        FileStream fs = null;
        Document monDocument = null;

        try
        {
            DataTable dt = Statistiques.InformationMission(numeroMission, planete);

            DataTable dtMembre = Statistiques.MembreMissionPrecise(numeroMission, planete);

            DataTable dtDepense = Statistiques.Depense(numeroMission, planete);

            DataTable dtInformateur = Statistiques.Informateur(numeroMission, planete);

            DataTable dtObjectifs = Statistiques.ObjectifCapture(numeroMission, planete);

            DataTable dtJournal = Statistiques.JournalDeBord(numeroMission, planete);

            DataTable dtNegociation = Statistiques.NégociationMission(numeroMission, planete);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Mission introuvable.");
                return;
            }

            fs = new FileStream(nomFichier, FileMode.Create);
            monDocument = new Document(PageSize.A4, 50, 50, 50, 50);

            PdfWriter writer = PdfWriter.GetInstance(monDocument, fs);

            writer.PageEvent = new PiedDePage();



            monDocument.Open();

            string cheminLogo = @"Images\Icones\logo_pdf.png";
            if (System.IO.File.Exists(cheminLogo))
            {
                //charge l'image
                iTextSharp.text.Image monLogo = iTextSharp.text.Image.GetInstance(cheminLogo);

                //dimension image (largeur, hauteur)
                monLogo.ScaleToFit(100f, 100f);

                //aligne à droite
                monLogo.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;

                monDocument.Add(monLogo);
                monDocument.Add(new Paragraph(" ")); //ajout ligne vide pour espacer 
            }


            //police d'ecriture
            Font policeTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLACK);
            Font sousTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
            Font text = FontFactory.GetFont(FontFactory.HELVETICA, 14, BaseColor.BLACK);
            Font policeDateJ = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK);
            Font policeAlerte = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.RED);




            //encadrer rapport de mission et placer au milieu 
            PdfPTable tableauTitre = new PdfPTable(1);
            tableauTitre.WidthPercentage = 70;
            PdfPCell caseTitre = new PdfPCell(new Phrase("RAPPORT DE MISSION N°" + numeroMission, policeTitre));
            caseTitre.HorizontalAlignment = Element.ALIGN_CENTER;
            caseTitre.VerticalAlignment = Element.ALIGN_MIDDLE;
            caseTitre.BorderWidth = 2f; //epaisseur trait 
            caseTitre.BorderColor = BaseColor.BLACK; //couleur trait
            caseTitre.Padding = 15f; //espace blanc entre texte et cadre
            tableauTitre.AddCell(caseTitre);
            monDocument.Add(tableauTitre);
            monDocument.Add(new Paragraph(" ")); //ajout ligne vide pour espacer 

            monDocument.Add(new Paragraph("Destination : " + dt.Rows[0]["nomPlanete"], sousTitre));

            //formate la date de départ
            string dateDepartFormatee = "Inconnue";
            if (dt.Rows[0]["dateDepart"] != DBNull.Value)
            {
                dateDepartFormatee = Convert.ToDateTime(dt.Rows[0]["dateDepart"]).ToString("dd/MM/yyyy");
            }

            //formate la date de retour
            string dateRetourFormatee = "Inconnue";
            if (dt.Rows[0]["dateRetour"] != DBNull.Value)
            {
                dateRetourFormatee = Convert.ToDateTime(dt.Rows[0]["dateRetour"]).ToString("dd/MM/yyyy");
            }

            monDocument.Add(new Paragraph("Départ le " + dateDepartFormatee, sousTitre));
            monDocument.Add(new Paragraph("Retour prévu le " + dateRetourFormatee, sousTitre));



            monDocument.Add(new Paragraph("--------------------------------------------------------------------------", policeTitre));
            monDocument.Add(new Paragraph("Chef de mission : " + dt.Rows[0]["nom"] + " " + dt.Rows[0]["prenom"], sousTitre));




            //ajout d'une liste de membre
            monDocument.Add(new Paragraph(" ")); //ajout ligne vide pour espacer 
            monDocument.Add(new Paragraph("Membres de l'équipe :", sousTitre));
            monDocument.Add(new Paragraph(" ")); //ajout ligne vide pour espacer 

            List listeMembres = new List(false, 10f);
            listeMembres.ListSymbol = new Chunk("• ", text);

            foreach (DataRow ligne in dtMembre.Rows)
            {
                listeMembres.Add(new ListItem(ligne["prenom"].ToString() + " " + ligne["nom"].ToString(), text));
            }
            monDocument.Add(listeMembres);

            monDocument.Add(new Paragraph(" ")); //ajout ligne vide pour espacer 







            //ajout des depenses + bilan depense
            monDocument.Add(new Paragraph("--------------------------------------------------------------------------", policeTitre));

            double budgetInitial = 0;

            if (dt.Rows[0]["budget"] != DBNull.Value)
            {
                // convertit en double pour faire des maths avec
                budgetInitial = Convert.ToDouble(dt.Rows[0]["budget"]);
            }

            monDocument.Add(new Paragraph("Budget Initial : " + dt.Rows[0]["budget"] + "€", sousTitre));
            monDocument.Add(new Paragraph(" "));

            double totalDepenses = 0;

            List listeDepense = new List(false, 10f);
            listeDepense.ListSymbol = new Chunk("- ", text);

            foreach (DataRow ligne in dtDepense.Rows)
            {
                //formate la date de la dépense
                string dateFormatee = "Date inconnue";
                if (ligne["dateD"] != DBNull.Value)
                {
                    dateFormatee = Convert.ToDateTime(ligne["dateD"]).ToString("dd/MM/yyyy");
                }

                //créer un élément de liste
                ListItem itemDepense = new ListItem();
                itemDepense.Leading = 18f; //aérer l'espacement des lignes
                itemDepense.SpacingAfter = 10f; ////ajout ligne vide pour espacer 

                //date en gras
                Chunk partieDate = new Chunk(dateFormatee + " : ", policeDateJ);

                string texteInfos = ligne["motif"].ToString() + " -> " + ligne["montant"].ToString() + "€";
                Chunk partieInfos = new Chunk(texteInfos, text);

                //on assemble
                itemDepense.Add(partieDate);
                itemDepense.Add(partieInfos);

                //oOn ajoute la ligne à la liste
                listeDepense.Add(itemDepense);

                //calcul du total des dépenses
                if (ligne["montant"] != DBNull.Value)
                {
                    totalDepenses += Convert.ToDouble(ligne["montant"]);
                }
            }
            monDocument.Add(listeDepense);

            monDocument.Add(new Paragraph(" ")); //ajout ligne vide pour espacer 

            double budgetRestant = budgetInitial - totalDepenses;

            monDocument.Add(new Paragraph("▶ Total des dépenses enregistrées : " + totalDepenses.ToString("F2") + " €", policeDateJ));
            if (budgetRestant < 0)
            {
                monDocument.Add(new Paragraph("▶ Budget restant : " + budgetRestant.ToString("F2") + " € (DÉPASSEMENT DE BUDGET !)", policeAlerte));
            }
            else
            {
                monDocument.Add(new Paragraph("▶ Budget restant : " + budgetRestant.ToString("F2") + " €", policeDateJ));
            }

            monDocument.Add(new Paragraph(" "));





            //ajout feuille de route 
            monDocument.Add(new Paragraph("--------------------------------------------------------------------------", policeTitre));
            monDocument.Add(new Paragraph("Feuille de route : ", sousTitre));
            monDocument.Add(new Paragraph(" "));

            //enlever les retour a la ligne sans que la phrase soit fini
            string feuilleTexte = dt.Rows[0]["feuilleDeRoute"].ToString();
            feuilleTexte = feuilleTexte.Replace("\r\n", "\n");
            feuilleTexte = feuilleTexte.Replace("\n\n", "##VRAI_PARAGRAPHE##");
            feuilleTexte = feuilleTexte.Replace("\n", " ");
            feuilleTexte = feuilleTexte.Replace("##VRAI_PARAGRAPHE##", "\n\n");

            while (feuilleTexte.Contains("  "))
            {
                feuilleTexte = feuilleTexte.Replace("  ", " ");
            }

            Paragraph pFeuille = new Paragraph(feuilleTexte, text);
            pFeuille.Leading = 18f;
            pFeuille.IndentationLeft = 15f;
            pFeuille.Alignment = Element.ALIGN_JUSTIFIED; //texte justifie
            monDocument.Add(pFeuille);

            monDocument.Add(new Paragraph(" ")); //ajout ligne vide pour espacer 






            //ajout informateur 
            monDocument.Add(new Paragraph("--------------------------------------------------------------------------", policeTitre));
            monDocument.Add(new Paragraph("Informateurs contactés : ", sousTitre));
            monDocument.Add(new Paragraph(" "));

            List listeInformateur = new List(false, 10f);
            listeInformateur.ListSymbol = new Chunk("- ", text);

            foreach (DataRow ligne in dtInformateur.Rows)
            {
                string dateFormatee = "Date inconnue";
                if (ligne["dateC"] != DBNull.Value)
                {
                    dateFormatee = Convert.ToDateTime(ligne["dateC"]).ToString("dd/MM/yyyy");
                }

                //creer liste vide
                ListItem itemInformateur = new ListItem();
                itemInformateur.Leading = 18f; //aérer l'espacement des ligne

                itemInformateur.SpacingAfter = 15f; //ajout ligne vide pour espacer 


                //date en gras
                Chunk partieDate = new Chunk(dateFormatee + " : ", policeDateJ);

                string texteInfos = "rencontre avec " + ligne["nom"].ToString() + " -> " + ligne["sommeVersee"].ToString() + "€\n\t• " + ligne["appreciation"].ToString() + "\n\t• " + ligne["commentaires"].ToString();
                Chunk partieInfos = new Chunk(texteInfos, text);


                itemInformateur.Add(partieDate);
                itemInformateur.Add(partieInfos);

                //ajoute l'élément terminé à la grande liste
                listeInformateur.Add(itemInformateur);

            }
            monDocument.Add(listeInformateur);

            monDocument.Add(new Paragraph(" ")); //ajout ligne vide pour espacer 





            //ajout des objectifs
            monDocument.Add(new Paragraph("--------------------------------------------------------------------------", policeTitre));
            monDocument.Add(new Paragraph("Objectifs de la mission : ", sousTitre));
            monDocument.Add(new Paragraph(" "));

            List listeObjectif = new List(false, 10f);
            listeObjectif.ListSymbol = new Chunk("- ", text);
            listeObjectif.Add(new ListItem("Databaz : " + dt.Rows[0]["objectifDatabaz"], text));



            ListItem itemCapture = new ListItem("Capture : ", text);
            List sousListeCaptures = new List(false, 15f);
            sousListeCaptures.ListSymbol = new Chunk("• ", text);

            foreach (DataRow ligne in dtObjectifs.Rows)
            {
                string espececible = ligne["nom"].ToString();
                string descriptionObjectif = ligne["objectif"].ToString();

                sousListeCaptures.Add(new ListItem(espececible + " : " + descriptionObjectif, text));

            }
            itemCapture.Add(sousListeCaptures);
            listeObjectif.Add(itemCapture);


            monDocument.Add(listeObjectif);
            monDocument.Add(new Paragraph(" "));




            //Journal de bord
            monDocument.Add(new Paragraph("--------------------------------------------------------------------------", policeTitre));
            monDocument.Add(new Paragraph("Journal de bord :", sousTitre));
            monDocument.Add(new Paragraph(" "));


            foreach (DataRow ligne in dtJournal.Rows)
            {
                string dateFormatee = "Date inconnue";
                if (ligne["dateJ"] != DBNull.Value)
                {
                    dateFormatee = Convert.ToDateTime(ligne["dateJ"]).ToString("dd/MM/yyyy");
                }

                //creer le paragraphe
                Paragraph pEntreeJournal = new Paragraph();
                pEntreeJournal.Leading = 18f; //espacement des lignes si le texte est sur plusieurs lignes
                pEntreeJournal.Alignment = Element.ALIGN_JUSTIFIED;

                //date en gras
                Chunk partieDate = new Chunk("- " + dateFormatee + " : ", policeDateJ);
                pEntreeJournal.Add(partieDate);


                Chunk partieCommentaire = new Chunk(ligne["commentaires"].ToString(), text);
                pEntreeJournal.Add(partieCommentaire);


                monDocument.Add(pEntreeJournal);
                monDocument.Add(new Paragraph(" ")); //espace entre deux jours
            }


            //Bilan capture

            if (tableBilan != null && tableBilan.Rows.Count > 0)
            {
                monDocument.Add(new Paragraph("--------------------------------------------------------------------------", policeTitre));
                monDocument.Add(new Paragraph("Bilan des captures :", sousTitre));
                monDocument.Add(new Paragraph(" "));

                PdfPTable tableauPdf = new PdfPTable(tableBilan.Columns.Count);
                tableauPdf.WidthPercentage = 100;

                Font policeEntete = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.WHITE);
                BaseColor couleurBleue = new BaseColor(0, 150, 255); //bleu 
                Font policeCellule2 = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);


                foreach (DataColumn colonne in tableBilan.Columns)
                {
                    PdfPCell celluleEntete = new PdfPCell(new Phrase(colonne.ColumnName, policeEntete));
                    celluleEntete.BackgroundColor = couleurBleue;
                    celluleEntete.HorizontalAlignment = Element.ALIGN_CENTER;
                    celluleEntete.Padding = 6f;
                    tableauPdf.AddCell(celluleEntete);
                }


                foreach (DataRow ligne in tableBilan.Rows)
                {
                    foreach (var cellule in ligne.ItemArray)
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(cellule.ToString(), policeCellule2));
                        pdfCell.Padding = 5f;
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        tableauPdf.AddCell(pdfCell);
                    }
                }
                monDocument.Add(tableauPdf);
                monDocument.Add(new Paragraph(" "));
            }


            //bilan databaz

            //on crée une DataTable pour le DataBaz
            DataTable tableBilanDataBaz = new DataTable("BilanDataBaz");
            tableBilanDataBaz.Columns.Add("Espèce alliée", typeof(string));
            tableBilanDataBaz.Columns.Add("Instrument échangé", typeof(string));
            tableBilanDataBaz.Columns.Add("Quantité obtenue", typeof(string));

            int totalDataBazObtenu = 0;

            //on remplit la table avec les données de la base
            if (dtNegociation != null && dtNegociation.Rows.Count > 0)
            {
                foreach (DataRow ligne in dtNegociation.Rows)
                {
                    string nomAllie = ligne["nom"].ToString();
                    string instrument = ligne["instrumentMusique"].ToString();
                    string qte = ligne["qteDataBaz"].ToString() + " tonnes";

                    tableBilanDataBaz.Rows.Add(nomAllie, instrument, qte);

                    if (ligne["qteDataBaz"] != DBNull.Value)
                    {
                        totalDataBazObtenu += Convert.ToInt32(ligne["qteDataBaz"]);
                    }
                }
            }
            else
            {
                //si il n'y a pas de negociation
                tableBilanDataBaz.Rows.Add("Aucune", "Aucun", "0 tonne");
            }

            //affiche le tableau
            monDocument.Add(new Paragraph("--------------------------------------------------------------------------", policeTitre));
            monDocument.Add(new Paragraph("Bilan de la récolte de DataBaz :", sousTitre));
            monDocument.Add(new Paragraph(" "));

            PdfPTable tableauDataBaz = new PdfPTable(tableBilanDataBaz.Columns.Count);
            tableauDataBaz.WidthPercentage = 100;

            Font policeEnteteVerte = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.WHITE);
            BaseColor couleurRose = new BaseColor(230, 20, 147); //rose
            Font policeCellule = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);

            //boucle sur les colonnes
            foreach (DataColumn colonne in tableBilanDataBaz.Columns)
            {
                PdfPCell celluleEntete = new PdfPCell(new Phrase(colonne.ColumnName, policeEnteteVerte));
                celluleEntete.BackgroundColor = couleurRose;
                celluleEntete.HorizontalAlignment = Element.ALIGN_CENTER;
                celluleEntete.Padding = 6f;
                tableauDataBaz.AddCell(celluleEntete);
            }

            //boucle sur les lignes et cellules
            foreach (DataRow ligne in tableBilanDataBaz.Rows)
            {
                foreach (var cellule in ligne.ItemArray)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(cellule.ToString(), policeCellule));
                    pdfCell.Padding = 5f;
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    tableauDataBaz.AddCell(pdfCell);
                }
            }
            monDocument.Add(tableauDataBaz);
            monDocument.Add(new Paragraph(" "));


            //affichage du résultat final en %
            int objectifDataBaz = 0;
            if (dt.Rows[0]["objectifDatabaz"] != DBNull.Value)
            {
                objectifDataBaz = Convert.ToInt32(dt.Rows[0]["objectifDatabaz"]);
            }

            if (objectifDataBaz > 0)
            {
                double tauxDataBaz = ((double)totalDataBazObtenu / objectifDataBaz) * 100;

                if (totalDataBazObtenu >= objectifDataBaz)
                {
                    Font policeSucces = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, new BaseColor(34, 139, 34));
                    monDocument.Add(new Paragraph("▶ Taux de réussite : " + Math.Round(tauxDataBaz, 0) + " %", policeSucces));
                }
                else
                {
                    monDocument.Add(new Paragraph("▶ Taux de réussite : " + Math.Round(tauxDataBaz, 0) + " %", text));
                }
                monDocument.Add(new Paragraph(" "));
            }



            monDocument.Add(new Paragraph(" "));


            Process.Start(new ProcessStartInfo(nomFichier) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erreur lors de la génération du PDF : " + ex.Message);
        }
        finally
        {
            if (monDocument != null && monDocument.IsOpen())
            {
                monDocument.Close();
            }
            if (fs != null)
            {
                fs.Dispose();
            }
        }
    }

    //pour le nummero de la page
    public class PiedDePage : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            Font policePage = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.GRAY);

            //on prépare le texte (ex: "Page 1")
            String texte = "Page " + writer.PageNumber;
            Phrase phrase = new Phrase(texte, policePage);

            //texte tout en bas, au centre de la page
            PdfContentByte cb = writer.DirectContent;
            ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, phrase, document.Right, document.Bottom - 20, 0);
        }
    }
}
