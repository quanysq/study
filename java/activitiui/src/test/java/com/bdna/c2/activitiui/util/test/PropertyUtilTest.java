package com.bdna.c2.activitiui.util.test;

import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

import com.bdna.c2.activitiui.util.PropertyUtil;

public class PropertyUtilTest {

	@Before
	public void setUp() throws Exception {
		
	}

	@Test
	public void testGetPropertyString() {
		String p = PropertyUtil.getProperty("restfulBaseUrl");
		String v = "http://192.168.10.102:8080";
		assertEquals(v, p);
	}

	@Test
	public void testGetPropertyStringString() {
		String p = PropertyUtil.getProperty("noItem", "abc");
		String v = "abc";
		assertEquals(v, p);
	}
}
