This chart was created by Kompose
https://docs.microsoft.com/en-us/azure/aks/kubernetes-walkthrough#code-try-12

# build Docker image
docker build -t myfrontend -f ./MyFrontEnd/Dockerfile .

docker build -f ./MyWebApi/Dockerfile -t mywebapi .

# run container end remove after use it
docker run --rm -it -p 9000:80 myfrontend

docker run --rm -it -p 9001:80 mywebapi

# test its
curl http://localhost:9001/weatherforecast
curl http://localhost:9000/privacy


---------------------------------------------------Azure ---------------------------------------------------------------------
az login


az aks get-credentials --resource-group myResourceGroup --name myAKSCluster
                                                                                You have logged in. Now let us find all the subscriptions to which you have access...
                                                                                [
                                                                                  {
                                                                                    "cloudName": "AzureCloud",
                                                                                    "id": "36a139de-7a36-4732-9b5e-ace7e185686f",
                                                                                    "isDefault": false,
                                                                                    "name": "Visual Studio Professional",
                                                                                    "state": "Disabled",
                                                                                    "tenantId": "0b3fc178-b730-4e8b-9843-e81259237b77",
                                                                                    "user": {
                                                                                      "name": "sorin.burtoiu@endava.com",
                                                                                      "type": "user"
                                                                                    }
                                                                                  },
                                                                                  {
                                                                                    "cloudName": "AzureCloud",
                                                                                    "id": "b1f03d80-e06c-4186-a96c-9c821146aadf",


kubectl config get-contexts
							                                    CURRENT   NAME                    CLUSTER                 AUTHINFO                                                     N
							                                    AMESPACE
							                                    *         MyAKSCluster            MyAKSCluster            clusterUser_myResourceGroup_MyAKSCluster
									                                      docker-desktop          docker-desktop          docker-desktop
									                                      sorted-pro-aks-dev-02   sorted-pro-aks-dev-02   clusterAdmin_rg-Sorted-WE-AKS-Dev-02_sorted-pro-aks-dev-02

docker tag myfrontend myazcontcontainerregistry.azurecr.io/myfrontend


az acr login -n myazcontcontainerregistry

docker push myazcontcontainerregistry.azurecr.io/myfrontend

docker tag mywebapi myazcontcontainerregistry.azurecr.io/mywebapi

docker push myazcontcontainerregistry.azurecr.io/mywebapi

#You also have to allow the AKS cluster to pull images from the ACR, using this command:
az aks update --name myAKSCluster --resource-group myResourceGroup --attach-acr myazcontcontainerregistry

az --version
-----------------------------------------------------------------------------------
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

curl http://52.191.36.123:8888


helm uninstall mywebapps-release

az group delete --name myResourceGroup --yes --no-wait




#list containers from a pod 
kubectl get pods mywebapi-deployment-77f4ccdcc5-m7t2b -o jsonpath='{.spec.containers[*].name}'


az acr repository list -n myazcontcontainerregistry