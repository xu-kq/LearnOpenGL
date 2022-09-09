#version 330 core
out vec4 fragColor;

in vec3 fragPos;
in vec3 Normal;

uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;
void main() {
	float ambient_strengh = 0.1;
	vec3 ambient = ambient_strengh * lightColor;

	vec3 norm = normalize(Normal);
	vec3 lightDir = normalize(lightPos - fragPos);

	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * lightColor;

	float specularStrength = 0.5;
	vec3 viewDir = normalize(viewPos - fragPos);
	vec3 reflectDir = reflect(-lightDir, norm);

	float spec = pow(max(dot(viewDir, reflectDir), 0), 32);
	vec3 specular = spec * specularStrength * lightColor;

	vec3 result = (ambient + diffuse + specular) * objectColor;
	fragColor = vec4(result, 1.0);
}