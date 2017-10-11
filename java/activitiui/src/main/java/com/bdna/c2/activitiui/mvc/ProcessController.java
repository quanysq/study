package com.bdna.c2.activitiui.mvc;

import org.apache.log4j.Logger;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import com.bdna.c2.activitiui.api.ProcessAPI;
import com.bdna.c2.activitiui.bean.DiagramResourceBean;
import com.bdna.c2.activitiui.bean.ProcessDefinitionsListBean;

@Controller
@RequestMapping("/")
public class ProcessController {
	private static final Logger logger = Logger.getLogger(ProcessAPI.class); 
	
	@RequestMapping(value="process-definitions", method= RequestMethod.GET)
	@ResponseBody
	public ProcessDefinitionsListBean GetProcessDefinitions(String basicAuth, Integer currentPage, Integer size) {
		ProcessDefinitionsListBean processDefinitionsListBean = null;
		try {
			processDefinitionsListBean = ProcessAPI.getProcessDefinitions(basicAuth, currentPage, size);
		} catch (Exception e) {
			logger.error("Error occurred when get process definitions: ", e);
			e.printStackTrace();
		}
		return processDefinitionsListBean;
	}
	
	@RequestMapping(value="process-diagram", method= RequestMethod.GET)
	@ResponseBody
	public DiagramResourceBean GetProcessDiagram(String url, String basicAuth) {
		DiagramResourceBean diagramResourceBean = null;
		try {
			diagramResourceBean = ProcessAPI.getProcessDiagram(url, basicAuth);
		} catch (Exception e) {
			logger.error("Error occurred when get process diagram: ", e);
			e.printStackTrace();
		}
		return diagramResourceBean;
	}
}
