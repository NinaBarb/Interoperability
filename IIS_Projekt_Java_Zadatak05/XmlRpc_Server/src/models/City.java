/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package models;

import javax.xml.bind.annotation.XmlElement;

/**
 *
 * @author Nina
 */
public class City {
    @XmlElement(name = "Grad")
    private String City;
    @XmlElement(name = "GradIme")
    private String CityName;
    @XmlElement(name = "Podatci")
    private String Data;
    @XmlElement(name = "Temp")
    private String Temp;

    public City() {
    }

    public City(String City, String CityName, String Data, String Temp) {
        this.City = City;
        this.CityName = CityName;
        this.Data = Data;
        this.Temp = Temp;
    }

    public String getCity() {
        return City;
    }

    public void setCity(String City) {
        this.City = City;
    }

    public String getCityName() {
        return CityName;
    }

    public void setCityName(String CityName) {
        this.CityName = CityName;
    }

    public String getData() {
        return Data;
    }

    public void setData(String Data) {
        this.Data = Data;
    }

    public String getTemp() {
        return Temp;
    }

    public void setTemp(String Temp) {
        this.Temp = Temp;
    }


    @Override
    public String toString() {
        return "Temerature in " + City + ": " + Temp + "\n";
    }
}
