/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package endpoints;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import jaxb.JAXB;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.client.XmlRpcClient;
import org.apache.xmlrpc.client.XmlRpcClientConfigImpl;

/**
 * REST Web Service
 *
 * @author Nina
 */
@Path("endpoints")
public class EndPoints {

    @Context
    private UriInfo context;
    /**
     * Creates a new instance of EndPoints
     */
    public EndPoints() {
    }

    /**
     * Retrieves representation of an instance of endpoints.EndPoints
     *
     * @param cityName
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_XML)
    public String getXml(@QueryParam("cityName")String cityName) {
        String result;
        try {
            XmlRpcClientConfigImpl config = new XmlRpcClientConfigImpl();
            config.setServerURL(new URL("http://localhost:8181/%22"));
            config.setEnabledForExceptions(true);
            config.setEnabledForExtensions(true);

            XmlRpcClient client = new XmlRpcClient();
            client.setConfig(config);

            Object[] city = new Object[]{cityName};
            result = (String) client.execute("RSSParser.searchByCityName", city);
        return result;
        } catch (MalformedURLException | XmlRpcException ex) {
            result = ex.getMessage();
            Logger.getLogger(EndPoints.class.getName()).log(Level.SEVERE, null, ex);
        }
        return result;
    }
    
    @GET
    @Path("jaxB")
    @Produces(MediaType.APPLICATION_XML)
    public void getJaxB() {
        JAXB.mainCaller();
    }

    /**
     * PUT method for updating or creating an instance of EndPoints
     *
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
}
