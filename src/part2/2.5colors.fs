#version 330 core

in vec3 Normal;
in vec3 FragPos;
in vec3 LightPos;

out vec4 Fragcolor;

uniform vec3 objectColor;
uniform vec3 lightColor;

void main()
{
    // ambient
	float ambientStrenth = 0.1;
	vec3 ambient = ambientStrenth * lightColor;
	
    // diffuse
	vec3 norm = normalize(Normal);
	vec3 lightDir = normalize(LightPos - FragPos);
	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * lightColor;
	
    // specular
	float specularStrenth = 0.5;
	vec3 viewDir = normalize(-FragPos);
	vec3 reflectDir = reflect(-lightDir, norm);
	float spec = pow(max(dot(viewDir, reflectDir), 0.0),32);
	vec3 specular = specularStrenth * spec * lightColor;
	
	vec3 result = (ambient + diffuse + specular) * objectColor;
	Fragcolor = vec4(result, 1.0);
}