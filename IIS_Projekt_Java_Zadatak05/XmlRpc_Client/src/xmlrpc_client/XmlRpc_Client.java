/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package xmlrpc_client;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.client.XmlRpcClient;
import org.apache.xmlrpc.client.XmlRpcClientConfigImpl;

/**
 *
 * @author Nina
 */
public class XmlRpc_Client {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try {
            XmlRpcClientConfigImpl config = new XmlRpcClientConfigImpl();
            config.setServerURL(new URL("http://localhost:8080/%22"));
            config.setEnabledForExceptions(true);
            config.setEnabledForExtensions(true);
            
            XmlRpcClient client = new XmlRpcClient();
            client.setConfig(config);
            
            String cityName = null;
            Scanner sc = new Scanner(System.in);
            System.out.print("Enter city name: ");
            cityName = sc.next();
            
            Object[] city = new Object[]{cityName};
            String ispis = (String) client.execute("RSSParser.searchByCityName", city);
            System.out.println(ispis);
        } catch (MalformedURLException | XmlRpcException ex) {
            Logger.getLogger(XmlRpc_Client.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

}
