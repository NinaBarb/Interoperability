/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parser;

import enums.TagType;
import hr.algebra.factory.ParserFactory;
import hr.algebra.factory.UrlConnectionFactory;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.util.ArrayList;
import java.util.List;
import javax.xml.stream.XMLEventReader;
import javax.xml.stream.events.StartElement;
import models.City;
import java.util.Optional;
import javax.xml.stream.XMLStreamConstants;
import javax.xml.stream.XMLStreamException;
import javax.xml.stream.events.Characters;
import javax.xml.stream.events.XMLEvent;

/**
 *
 * @author Nina
 */
public class RSSParser {

    private static final String RSS_URL = "https://vrijeme.hr/hrvatska_n.xml";

    public String searchByCityName(String cityName) throws IOException, XMLStreamException {

        List<City> cities = new ArrayList<>();

        HttpURLConnection con = UrlConnectionFactory.getHttpUrlConnection(RSS_URL);

        try (InputStream is = con.getInputStream()) {
            XMLEventReader reader = ParserFactory.createStaxParser(is);

            StartElement startElement = null;
            Optional<TagType> tagType = Optional.empty();
            City city = null;
            while (reader.hasNext()) {
                XMLEvent event = reader.nextEvent();
                switch (event.getEventType()) {
                    case XMLStreamConstants.START_ELEMENT:
                        startElement = event.asStartElement();
                        String qName = startElement.getName().getLocalPart();
                        tagType = TagType.from(qName);
                        break;
                    case XMLStreamConstants.CHARACTERS:
                        Characters characters = event.asCharacters();
                        String data = characters.getData().trim();
                        if (tagType.isPresent()) {
                            switch (tagType.get()) { //item, title, link, description...
                                case CITY:
                                    city = new City();
                                    cities.add(city);
                                    break;
                                case CITYNAME:
                                    if (city != null && !data.isEmpty()) {
                                        city.setCity(data);
                                    }
                                    break;
                                case DATA:
                                    if (city != null && !data.isEmpty()) {
                                        city.setData(data);
                                    }
                                    break;
                                case TEMP:
                                    if (city != null && !data.isEmpty()) {
                                        city.setTemp(data);
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }
        String cityTemp = null;

        for (City c : cities) {
            if (cityName.equals(c.getCity())) {
                cityTemp = c.toString();
                break;
            }
        }

        if (cityTemp == null) {
            return "City doesn't exist!";
        }

        return cityTemp;
    }
}
