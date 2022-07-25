/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package enums;

import java.util.Optional;

/**
 *
 * @author Nina
 */
public enum TagType {
    CITY("Grad"),
    CITYNAME("GradIme"),
    DATA("Podatci"),
    TEMP("Temp");

    private final String name;

    private TagType(String name) {
        this.name = name;
    }

    public static Optional<TagType> from(String name){
        for (TagType value:values()) {
            if (value.name.equals(name)) {
                return Optional.of(value);
            }
        }
        return Optional.empty();
    }
}
