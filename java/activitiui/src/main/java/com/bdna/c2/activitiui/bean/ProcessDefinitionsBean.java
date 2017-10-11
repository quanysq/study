package com.bdna.c2.activitiui.bean;

public class ProcessDefinitionsBean {
	private String id;
	private String url;
	private String key;
	private String version;
	private String name;
	private String description;
	private String tenantId;
	private String deploymentId;
	private String deploymentUrl;
	private String resource;
	private String diagramResource;
	private String category;
	private Boolean graphicalNotationDefined;
	private Boolean suspended;
	private Boolean startFormDefined;
	
	public ProcessDefinitionsBean() {
		
	}
	
	public String getId() {
		return id;
	}
	
	public void setId(String id) {
		this.id = id;
	}
	
	public String getUrl() {
		return url;
	}
	
	public void setUrl(String url) {
		this.url = url;
	}
	
	public String getKey() {
		return key;
	}
	
	public void setKey(String key) {
		this.key = key;
	}
	
	public String getVersion() {
		return version;
	}
	
	public void setVersion(String version) {
		this.version = version;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public String getDescription() {
		return description;
	}
	
	public void setDescription(String description) {
		this.description = description;
	}
	
	public String getTenantId() {
		return tenantId;
	}
	
	public void setTenantId(String tenantId) {
		this.tenantId = tenantId;
	}
	
	public String getDeploymentId() {
		return deploymentId;
	}
	
	public void setDeploymentId(String deploymentId) {
		this.deploymentId = deploymentId;
	}
	
	public String getDeploymentUrl() {
		return deploymentUrl;
	}
	
	public void setDeploymentUrl(String deploymentUrl) {
		this.deploymentUrl = deploymentUrl;
	}
	
	public String getResource() {
		return resource;
	}
	
	public void setResource(String resource) {
		this.resource = resource;
	}
	
	public String getDiagramResource() {
		return diagramResource;
	}
	
	public void setDiagramResource(String diagramResource) {
		this.diagramResource = diagramResource;
	}
	
	public String getCategory() {
		return category;
	}
	
	public void setCategory(String category) {
		this.category = category;
	}
	
	public Boolean getGraphicalNotationDefined() {
		return graphicalNotationDefined;
	}
	
	public void setGraphicalNotationDefined(Boolean graphicalNotationDefined) {
		this.graphicalNotationDefined = graphicalNotationDefined;
	}
	
	public Boolean getSuspended() {
		return suspended;
	}
	
	public void setSuspended(Boolean suspended) {
		this.suspended = suspended;
	}
	
	public Boolean getStartFormDefined() {
		return startFormDefined;
	}
	
	public void setStartFormDefined(Boolean startFormDefined) {
		this.startFormDefined = startFormDefined;
	}
}
