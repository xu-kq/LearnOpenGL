#version 330 core
out vec4 fragColor;

in vec3 fragPos;
in vec3 Normal;
in vec3 light_Pos;

uniform vec3 objectColor;
uniform vec3 lightColor;
void main() {
	float ambient_strengh = 0.1;
	vec3 ambient = ambient_strengh * lightColor;

	vec3 norm = normalize(Normal);
	vec3 lightDir = normalize(light_Pos - fragPos);

	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * lightColor;

	float specularStrength = 0.5;
	vec3 viewDir = normalize(- fragPos);
	vec3 reflectDir = reflect(-lightDir, norm);

	float spec = pow(max(dot(viewDir, reflectDir), 0), 32);
	vec3 specular = spec * specularStrength * lightColor;

	vec3 result = (ambient + diffuse + specular) * objectColor;
	fragColor = vec4(result, 1.0);
}