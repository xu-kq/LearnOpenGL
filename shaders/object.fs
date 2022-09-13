#version 330 core
struct Material {
	sampler2D diffuse;
	sampler2D specular;
//	sampler2D emission;
	float shininess;
};

struct Light {
	vec3 direction;
	vec3 position;

	float cutOff;
	float outerCutOff;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;

	float constant;
	float linear;
	float quadratic;
};

out vec4 fragColor;

in vec3 fragPos;
in vec3 Normal;
in vec2 TexCoords;

uniform Material material;
uniform Light light;
void main() {
	vec3 lightDir = normalize(light.position - fragPos);
	float theta     = dot(lightDir, normalize(-light.direction));
	float epsilon   = light.cutOff - light.outerCutOff;
	float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.01, 1.0); 
    


	float distance = length(light.position - fragPos);
	float attenuation = 1.0 / (light.constant + light.linear * distance 
		+ light.quadratic * distance * distance);

	vec3 norm = normalize(Normal);


	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * vec3(texture(material.diffuse, TexCoords))* light.diffuse;

	vec3 viewDir = normalize(- fragPos);
	vec3 reflectDir = reflect(-lightDir, norm);

	float spec = pow(max(dot(viewDir, reflectDir), 0), material.shininess);
	vec3 specular = (spec * vec3(texture(material.specular, TexCoords))) * light.specular;

	vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoords));

	//vec3 emission = texture(material.emission, TexCoords).rgb;

	vec3 result = ambient + diffuse + specular;// + emission;
	result *= attenuation * intensity;
	fragColor = vec4(result, 1.0);



}