package com.bdna.c2.activitiui.util;

import java.io.*;
import java.util.Properties;

import org.apache.log4j.Logger;

public class PropertyUtil {
	private static final Logger logger = Logger.getLogger(PropertyUtil.class);
    private static Properties props;
    static{
        loadProps();
    }
    
    synchronized static private void loadProps(){
        logger.info("Reading Properties file...");
        props = new Properties();
        InputStream in = null;
        try {
        	in = PropertyUtil.class.getClassLoader().getResourceAsStream("activitiui.properties");
            props.load(in);
        } catch (FileNotFoundException e) {
            logger.error("Not found activitiui.properties");
        } catch (IOException e) {
            logger.error("Error occurred when Reading Properties file: ", e);
        } finally {
            try {
                if(null != in) {
                    in.close();
                }
            } catch (IOException e) {
                logger.error("Can't close file stream: ", e);
            }
        }
        logger.info("Readed Properties file successfully!");
        logger.info("properties content is£º" + props);
    }

    public static String getProperty(String key){
        if(null == props) {
            loadProps();
        }
        return props.getProperty(key);
    }

    public static String getProperty(String key, String defaultValue) {
        if(null == props) {
            loadProps();
        }
        return props.getProperty(key, defaultValue);
    }
}
