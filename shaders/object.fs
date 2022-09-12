#version 330 core
struct Material {
	sampler2D diffuse;
	sampler2D specular;
	float shininess;
};

struct Light {
	vec3 position;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};

out vec4 fragColor;

in vec3 fragPos;
in vec3 Normal;
in vec3 light_Pos;
in vec2 TexCoords;

uniform Material material;
uniform Light light;
void main() {

	vec3 norm = normalize(Normal);
	vec3 lightDir = normalize(light.position - fragPos);

	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * vec3(texture(material.diffuse, TexCoords))* light.diffuse;

	vec3 viewDir = normalize(- fragPos);
	vec3 reflectDir = reflect(-lightDir, norm);

	float spec = pow(max(dot(viewDir, reflectDir), 0), material.shininess);
	vec3 specular = (spec * vec3(texture(material.specular, TexCoords))) * light.specular;

	vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoords));

	vec3 result = ambient + diffuse + specular;
	fragColor = vec4(result, 1.0);
}