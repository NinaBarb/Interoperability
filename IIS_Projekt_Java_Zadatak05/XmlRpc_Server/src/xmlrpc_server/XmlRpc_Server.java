/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package xmlrpc_server;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.server.PropertyHandlerMapping;
import org.apache.xmlrpc.server.XmlRpcServer;
import org.apache.xmlrpc.server.XmlRpcServerConfigImpl;
import org.apache.xmlrpc.webserver.WebServer;
import parser.RSSParser;

/**
 *
 * @author Nina
 */
public class XmlRpc_Server {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try {
            WebServer server = new WebServer(8181);
            
            XmlRpcServer xmlServer = server.getXmlRpcServer();
            PropertyHandlerMapping phm = new PropertyHandlerMapping();
            phm.addHandler("RSSParser", RSSParser.class);
            xmlServer.setHandlerMapping(phm);
            
            //config
            XmlRpcServerConfigImpl config = (XmlRpcServerConfigImpl) xmlServer.getConfig();
            config.setEnabledForExceptions(true);
            config.setContentLengthOptional(false);
            //za decimalnu tocku na true
            config.setEnabledForExtensions(true);
            
            server.start();
        } catch (IOException | XmlRpcException ex) {
            Logger.getLogger(XmlRpc_Server.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
}
