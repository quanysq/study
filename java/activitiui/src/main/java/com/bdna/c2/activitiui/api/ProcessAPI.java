package com.bdna.c2.activitiui.api;

import org.apache.log4j.Logger;

import com.bdna.c2.activitiui.bean.DiagramResourceBean;
import com.bdna.c2.activitiui.bean.ProcessDefinitionsListBean;
import com.bdna.c2.activitiui.util.HttpClientUtil;

public class ProcessAPI {
	private static final Logger logger = Logger.getLogger(ProcessAPI.class); 
	
	public static ProcessDefinitionsListBean getProcessDefinitions(String basicAuth, Integer currentPage, Integer size) throws Exception {
		logger.info("Starting to get process definitions info...");
		Integer start = (currentPage-1) * size;
		String url = String.format("/activiti-rest/service/repository/process-definitions?start=%d&size=%d", start, size);
		ProcessDefinitionsListBean processDefinitionsListBean = HttpClientUtil.httpGet(url, basicAuth, ProcessDefinitionsListBean.class, true);
		logger.info("Get process definitions info successfully...");
		return processDefinitionsListBean;
	}
	
	public static DiagramResourceBean getProcessDiagram(String url, String basicAuth) throws Exception {
		logger.info("Starting to get process diagram info...");
		DiagramResourceBean diagramResourceBean = HttpClientUtil.httpGet(url, basicAuth, DiagramResourceBean.class, false);
		logger.info("Get process diagram info successfully...");
		logger.info(diagramResourceBean.getContentUrl());
		return diagramResourceBean;
	}
}
