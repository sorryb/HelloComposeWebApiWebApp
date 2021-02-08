This chart was created by Kompose: Kompose convert -c


# build Docker image
docker build -t myfrontend -f ./MyFrontEnd/Dockerfile .

docker build -f ./MyWebApi/Dockerfile -t mywebapi .

# run container end remove after use it
docker run --rm -it -p 9000:80 myfrontend

docker run --rm -it -p 9001:80 mywebapi

# test its
curl http://localhost:9001/weatherforecast
curl http://localhost:9000/privacy

# install chart

helm install mywebapps-release ./Helm/

																		NAME: mywebapps-release
																		LAST DEPLOYED: Thu Oct  8 19:35:57 2020
																		NAMESPACE: default
																		STATUS: deployed
																		REVISION: 1
																		TEST SUITE: None



kubectl config get-contexts												# display list of contexts and clusters

kubectl config use-context docker-desktop								# means Docker Desktop


kubectl get all --selector app=weather-forecast							# where 'mywebapp' is the label from values.yaml

kubectl get deployments

kubectl get pods

kubectl get services

##if service type is ClusterIP
kubectl port-forward service/webapp 9999:8888
curl http://localhost:9999

##if service type is LoadBalancer
curl http://localhost:8888

helm uninstall mywebapps-release


#list containers from a pod 
kubectl get pods mywebapi-deployment-77f4ccdcc5-m7t2b -o jsonpath='{.spec.containers[*].name}'