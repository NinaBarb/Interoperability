/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jaxb;

import generated.Games;
import java.io.File;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;

/**
 *
 * @author Nina
 */
public class JAXB {

    /**
     * @param args the command line arguments
     */
    private static final String PATH = "D:\\skola\\IIS\\IIS_Projekt_NBarbarić\\IIS_Projekt_NinaBarbarić\\Zadatak03\\Schemas\\game.xml";
    private static final String RESULT = "D:\\skola\\IIS\\JAXB_Result.txt";
    static int count = 0;

    public static void mainCaller() {
        count++;

        if (count < 1) {
            main(null);
        }
    }

    public static void main(String[] args) {
        try {
            JAXBContext jc = JAXBContext.newInstance(Games.class);
            Marshaller m = jc.createMarshaller();
            m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);

            Unmarshaller u = jc.createUnmarshaller();
            Games games = (Games) u.unmarshal(new File(PATH));

            /*m.marshal(games, System.out);*/
            m.marshal(games, new File(RESULT));

        } catch (JAXBException ex) {
            Logger.getLogger(JAXB.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

}
