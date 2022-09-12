cmake_minimum_required(VERSION 3.10)

# vcpkg 
find_path(vcpkg_path vcpkg.exe)
set(CMAKE_TOOLCHAIN_FILE ${vcpkg_path}/scripts/buildsystems/vcpkg.cmake)


set(CMAKE_CXX_STANDARD 11)
project(Render)
add_executable(Render "main.cpp" "Shader.cpp" "stb_image.cpp")


# glad
find_package(glad CONFIG REQUIRED)
target_link_libraries(Render PRIVATE glad::glad)


# glfw3
find_package(glfw3 CONFIG REQUIRED)
target_link_libraries(Render PRIVATE  glfw)

# glm
find_package(glm CONFIG REQUIRED)
target_link_libraries(Render PRIVATE glm::glm)