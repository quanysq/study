package com.bdna.c2.activitiui.bean;

import java.util.List;

public class ProcessDefinitionsListBean {
	private List<ProcessDefinitionsBean> data;
	private Integer total;
	private Integer start;
	private String sort;
	private String order;
	private Integer size;
	
	public ProcessDefinitionsListBean() {
		
	}
	
	public List<ProcessDefinitionsBean> getData() {
		return data;
	}
	
	public void setData(List<ProcessDefinitionsBean> data) {
		this.data = data;
	}
	
	public Integer getTotal() {
		return total;
	}
	
	public void setTotal(Integer total) {
		this.total = total;
	}
	
	public Integer getStart() {
		return start;
	}
	
	public void setStart(Integer start) {
		this.start = start;
	}
	
	public String getSort() {
		return sort;
	}
	
	public void setSort(String sort) {
		this.sort = sort;
	}
	
	public String getOrder() {
		return order;
	}
	
	public void setOrder(String order) {
		this.order = order;
	}
	
	public Integer getSize() {
		return size;
	}
	
	public void setSize(Integer size) {
		this.size = size;
	}
}
